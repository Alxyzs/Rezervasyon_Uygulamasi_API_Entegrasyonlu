using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;
using ReservationApiUygulamasi.WebApi.Hubs;

namespace ReservationApiUygulamasi.WebApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //Auth olduktan sorna calıssın dıye eklendi
	public class ReservationsController : ControllerBase
	{

		private readonly ApiContext _context;
		private readonly IValidator<CreateReservationDto> _validator; //BuFludentValidation içindir kuralları kontrol eder sadece .
		private readonly StockHubTransmitter _transMitter; //Bu ise SignalR ile YENI REZERVASYON EKLEDİndi ve stok azalır buyuzden stok güncellemelerini bildirmek için kullanılır yani MESAJ,BİLDİRİM İÇİN Ctor'da belirtilmeli .Kullanılacak yerdede enjekte edilip kullanılır ASağda örnek POST'da.


		public ReservationsController(IValidator<CreateReservationDto> validator, ApiContext context, StockHubTransmitter transMitter)
		{
			_validator = validator;
			_context = context;
			_transMitter = transMitter;
		}


		[HttpGet]
		public async Task<ActionResult<List<ReservationDto>>> GetAll()
		{
			if (_context.ReservationDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null."); //NUL Referencess Hatası için .

			var values = await _context.ReservationDto.ToListAsync();

			//return Ok(values); eski zata 200 Kod döndürür ve VALUES'i
			return Ok(new ApiResponse<List<ReservationDto>>
			{
				Success = true,
				Message = "Rezervasyonlar listelendi",
				Data = values
				//Data = new DataResponse<List<ReservationDto>> { Data = values } //Bu yapıda {}parantez icinde gosterme mantığı iste .
			});//Bu Yapı ise Tam Response Yapsını ve ApiResponse sınıfı ise standart bir API cevabı yapısıdır . Success Message ve Data gibi alanları içerir | APIden dönen cevabın tutarlı ve anlaşılır olmasını sağlar.
		}



		[HttpPost] //Diğerinden Farklı Olarak ROWVERSİON GONDERMEDEN POST İŞLEMI YAPMAK İÇİN AYRI BİR DTO OLUŞTURDUM . 
		public async Task<IActionResult> Create([FromBody] CreateReservationDto dto)
		{
			if (_context.ReservationDto == null)
				return Problem("ApiContext.ReservationDto is null.");

			var validationResult = await _validator.ValidateAsync(dto);
			if (!validationResult.IsValid)
				return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));

			var entity = new ReservationDto
			{
				ProductRef = dto.ProductRef,
				ReservedQty = dto.ReservedQty,
				Notes = dto.Notes,
				UserID = dto.UserID,
				DATE = DateTime.UtcNow
			};

			await _context.ReservationDto.AddAsync(entity); 
			await _context.SaveChangesAsync();

			//Burada SignalR ile Stok bildirimi gönderilir . Stok güncellendiğinde tüm bağlı istemcilere bildirim gönderilir ve stok durumunu güncellemeleri sağlanır 
			await _transMitter.UpdateStocksAsync(new
			{
				Message = "Udpdate Stocks . Refresh Page ",
				UpdateAt = DateTime.UtcNow,
				Product = dto.ProductRef,
				Quantity = dto.ReservedQty
			});

			return Ok("Rezervasyon eklendi");
		}


		//#region EskiPostMethodu RowVersion Kalktı onun için yeni sınıf olusutruldu
		//[HttpPost]
		//public async Task<IActionResult> Create([FromBody] ReservationDto dto)
		//{
		//	if (_context.ReservationDto == null)
		//		return Problem(" 'ApiContext.ReservationDto'  is null.");

		//   // Validasyon için eğer calıstıgında bi hata gelirse BadRequest döndürür ve hataları listeler . FluentValidation kullanarak validasyon yapıldı 
		//	var validationResult = await _validator.ValidateAsync(dto);
		//	if (!validationResult.IsValid)
		//		return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
		//	//


		//	var entity = new ReservationDto
		//	{
		//		ProductRef = dto.ProductRef,
		//		ReservedQty = dto.ReservedQty,
		//		Notes = dto.Notes,
		//		UserID = dto.UserID,
		//		DATE = DateTime.UtcNow
		//	};

		//	await _context.ReservationDto.AddAsync(entity);
		//	await _context.SaveChangesAsync();
		//	return Ok("Rezervasyon eklendi");
		//}
		//#endregion



		[HttpGet("{Id}")]//ID'ye göre arama
		public async Task<ActionResult<ReservationDto>> GetById(int Id)
		{
			if (_context.ReservationDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null.");

			var reservation = await _context.ReservationDto.FindAsync(Id);

			if (reservation == null)
				return NotFound("Rezervasyon bulunamadı.");

			return Ok(reservation);
		}



		[HttpDelete("{Id}")]
		public async Task<IActionResult> DeleteProduct(int Id)
		{
			if (_context.ReservationDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null.");

			var reservation = await _context.ReservationDto.FindAsync(Id);
			if (reservation == null) return NotFound("Rezervasyon bulunamadı.");

			_context.ReservationDto.Remove(reservation);
			await _context.SaveChangesAsync();
			return Ok("Rezervasyon silindi");
		}


		
		//UPDATE İÇİN
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateReservationDto dto)
		{
			var entity = await _context.ReservationDto.FirstOrDefaultAsync(x => x.Id == dto.Id);

			if (entity == null)
				return NotFound();

			if (string.IsNullOrEmpty(dto.RowVersion))
				return BadRequest("RowVersion zorunludur.");

			byte[] rowVersionBytes;
			try
			{
				rowVersionBytes = Convert.FromBase64String(dto.RowVersion);
			}
			catch
			{
				return BadRequest("RowVersion geçersiz format.");
			}

			_context.Entry(entity).OriginalValues["RowVersion"] = rowVersionBytes;

			entity.ProductRef = dto.ProductRef;
			entity.ReservedQty = dto.ReservedQty;
			entity.Notes = dto.Notes;
			entity.UserID = dto.UserID;

			try
			{
				await _context.SaveChangesAsync();
				return Ok("Güncellendi");
			}
			catch (DbUpdateConcurrencyException)
			{
				return Conflict("Başka biri güncelledi");
			}
		}

	}
}