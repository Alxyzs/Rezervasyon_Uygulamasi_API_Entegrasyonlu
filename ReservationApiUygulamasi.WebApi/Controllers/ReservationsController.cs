using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;

namespace ReservationApiUygulamasi.WebApi.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //Auth olduktan sorna calıssın dıye eklendi
	public class ReservationsController : ControllerBase
	{

		private readonly ApiContext _context;
		private readonly IValidator<CreateReservationDto> _validator; //BuFludentValidation içindir kuralları kontrol eder sadece .

		public ReservationsController(IValidator<CreateReservationDto> validator, ApiContext context)
		{
			_validator = validator;
			_context = context;
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

			await _context.ReservationDto.AddAsync(entity); // ✔ DOĞRU
			await _context.SaveChangesAsync();

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


	}
}