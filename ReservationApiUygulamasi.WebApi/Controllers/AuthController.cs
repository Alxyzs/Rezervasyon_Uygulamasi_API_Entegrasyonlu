using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text; // Encoding.UTF8.GetBytes kullanımı için gerekli - signing key'i byte array'e dönüştürmek için kullanılır.
using System.Security.Claims; // Bu Claims kullanımı için gerekli - token içerisinde taşınacak bilgileri temsil eder.
using Microsoft.IdentityModel.Tokens;//Bu JwtSecurityToken ve SymmetricSecurityKey kullanımı için gerekli - token oluşturma ve imzalama işlemleri için kullanılır.

using ReservationApiUygulamasi.EL;
using Microsoft.AspNetCore.Identity.Data;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.BLL;
using ReservationApiUygulamasi.EL.QueryModels;
namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		//Appsettings için eklendi
		private readonly IConfiguration _configuration;
		public AuthController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost] //IActionResul API'den gelen isteğin KOdunu ve sonucunu temsil eder . örn Unathtroız401 , BadRequest400, Ok200 gibi döndurur yanı StringYerıne falan alır gelen değerin cevabını kontrol ederiz .Hata mesjaı gostermek için
		public IActionResult Get([FromBody]LoginRequestApi loginRequest)
		{

			#region Appsettings.json dosyasından çekilen bilgiler
				var signinKey = _configuration["JwtConfig:SigningKey"];
				var audience  = _configuration["JwtConfig:Audience"];
				var Isuuer	  = _configuration["JwtConfig:Issuer"];
			#endregion

			var accaountStatus = QueryBLL.GetSearchUser(loginRequest.Username ?? "", loginRequest.Password ?? "");
			if (accaountStatus == null || accaountStatus.Count == 0 )
				return Unauthorized("Kullanıcı adı veya şifre hatalı.");

			InstantUser.UserID = accaountStatus.FirstOrDefault().ID;


			var claims = new[]
			{
				new Claim(ClaimTypes.Name,loginRequest.Username ?? ""),
				new Claim(ClaimTypes.Email,loginRequest.Password ?? "")
			}; //BUNLAR OLMASADA OLUR CLAİM'ler - Kullanıcı adı, rol gibi bilgileri taşımak için kullanılır ek bilgileri .
				
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey ?? "")); // Swaggerdan gelen string'i byte array'e dönüştürmek için kullanılır. Bu, token'ı imzalamak için gerekli olan gizli anahtarı temsil eder.
			var credentialsSecurityKey = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256); // Token'ı imzalamak için kullanılan algoritmayı ve güvenlik anahtarını belirtir . Token'ın güvenliğini sağlar.
		
			var jwtSecurityToken = new JwtSecurityToken(

				//Genelde burada kullanılmaz ki heryerden cağırabilelim diye . Ornektir
				issuer: "http://192.168.1.80:5003", //token üreten API adresi
				audience: "BuOrnekAudience", //buraya token'ı kullanacak API adresi gelecek
				claims: claims, //token içerisinde taşınacak bilgiler
				expires: DateTime.Now.AddDays(1), //token'ın geçerlilik süresi
				notBefore : DateTime.Now, //token'ın ne zaman geçerli olmaya başlayacağı Alındığı gibi .
				signingCredentials : credentialsSecurityKey //token'ı imzalamak için kullanılan güvenlik anahtarı ve algoritma bilgisi .

			);

			var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken); //Burası token'ı string formatına dönüştürür ve client'a gönderilir . Token'ı oluşturur ve string formatına dönüştürür.Kullanıcıya döndürülecek olan token'ı oluşturur ve string formatına dönüştürür.
			
			//return Ok(token); eski'de responsede sadece Token dönerdi

			return Ok(new ApiResponse<string>
			{
				Success = true,
				Message = "Token oluşturuldu",
				Data = token
			}); //Bu Yapı ise Tam Response Yapsısını ve ApiResponse sınıfı ise standart bir API cevabı yapısıdır . Success Message ve Data gibi alanları içerir | APIden dönen cevabın tutarlı ve anlaşılır olmasını sağlar.

		}

		[HttpGet("ValidateToken")] // Yukarda ALınan Tokenı doğrulamak için bir endpoint oluşturduk . Token doğrulama işlemi için kullanılır. Token'ın geçerliliğini kontrol eder. YUKARDAKI TOKENI OLUSUTRMA .
		public IActionResult ValidateToken(string token)
		{
			var signinKey = _configuration["JwtConfig:SigningKey"];
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey ?? "" ));
			try
			{
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				tokenHandler.ValidateToken(token, new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true, //token'ı imzalayan güvenlik anahtarını doğrulamak istiyorsak true yaparız
					IssuerSigningKey = securityKey, //token'ı imzalayan güvenlik anahtarı bilgisi
					ValidateLifetime = true, //token'ın geçerlilik süresini doğrulamak istiyorsak true yaparız
					ValidateIssuer = false, //token'ı üreten API adresini doğrulamak istemiyorsak false yaparız
					ValidateAudience = false //token'ı kullanacak API adresini doğrulamak istemiyorsak false yaparız
				} , out SecurityToken validatedToken);

				var jwToken = (JwtSecurityToken)validatedToken; //doğrulanan token'ı JwtSecurityToken tipine dönüştürürüz . Doğrulanan token'ı JwtSecurityToken tipine dönüştürerek token içerisindeki bilgilere erişebiliriz. 
				var claims = jwToken.Claims.ToList(); //token içerisindeki bilgileri alırız . Örneğin, kullanıcı adı, email gibi bilgileri claims üzerinden alabiliriz.

				return Ok(true);
			}
			catch(Exception)
			{
				 return Unauthorized("Süresi Geçmiş veya Hatalı TOKEN !"); ;
			}
		}

	}
}
