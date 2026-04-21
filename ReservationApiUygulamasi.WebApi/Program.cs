using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;
using ReservationApiUygulamasi.WebApi.ValidationRules;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiContext>();

// VALIDATOR calýsmasý icin eklendi .
builder.Services.AddScoped<IValidator<ReservationDto>,ReservationValidator>();
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// --builder.Services.AddSwaggerGen(); bunun yerýne Authroýze ýcýn alttdaki kod Eklendi

//AddSwaggerGen()
#region AddSwaggerGen için Authorize butonu eklemek için gerekli kodlar
	builder.Services.AddSwaggerGen(options =>
	{
		options.SwaggerDoc("v1", new OpenApiInfo
		{
			Title = "ReservationApplication.API",
			Version = "v1"
		});
	
		// JWT Authorize butonu için
		options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
		{
			Name = "Authorization",
			Type = SecuritySchemeType.Http,
			Scheme = "bearer",
			BearerFormat = "JWT",
			In = ParameterLocation.Header,
			Description = "Token gir: Bearer {token}"
		});
	
		options.AddSecurityRequirement(new OpenApiSecurityRequirement
		{
			{
				new OpenApiSecurityScheme
				{
					Reference = new OpenApiReference
					{
						Type = ReferenceType.SecurityScheme,
						Id = "Bearer"
					}
				},
				new string[] {}
			}
		});
	});
#endregion
//
	
// ----- AUTH ÝÇÝN EKLENDÝ - BENIM JWT TOKEN .
#region Authorize için 

	var issur = builder.Configuration["JwtConfig:Issuer"]; //Appsettings.json dosyasýndaki JwtConfig bölümündeki bilgiyi alýr 
	var audience = builder.Configuration["JwtConfig:Audience"]; 
	var signinKey = builder.Configuration["JwtConfig:SigningKey"]; 
	
	builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>{
	
			options.TokenValidationParameters = new TokenValidationParameters
			{
	
				ValidateIssuer = true, //token'ý üreten API adresini doðrulamak istiyorsak true yaparýz
				ValidateAudience = true, //token'ý kullanacak API adresini doðrulamak istiyorsak true yaparýz
				ValidateLifetime = true, //token'ýn geçerlilik süresini doðrulamak istiyorsak true yaparýz
				ValidateIssuerSigningKey = true, //token'ý imzalayan güvenlik anahtarýný doðrulamak istiyorsak true yaparýz
				ValidIssuer = issur,
				ValidAudience = audience,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signinKey ?? "")) //token'ý imzalayan güvenlik anahtarý bilgisi
	
			};
		});
	
#endregion
// ----
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	//app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();//Bu Authorize için Authorizeden önce olacak

app.UseMiddleware<LogMiddleware>(); //LogMiddleware'i kullanarak gelen istekleri ve giden cevaplarý loglamak için ekledik . Loglama iþlemi için kullanýlýr. Gelen isteklerin ve giden cevaplarýn detaylarýný kaydeder.

app.UseAuthorization();

app.MapControllers();

app.Run();
