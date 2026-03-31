using Microsoft.AspNetCore.Mvc;
using ReservationApiUygulamasi.WebApi.Context;
using ReservationApiUygulamasi.EL.ApiModels;
using Microsoft.AspNetCore.Authorization;

namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //Auth olduktan sorna calıssın dıye eklendi
	public class ReservationsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ReservationsController()
		{
			_context = new ApiContext();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ReservationDto dto)
		{
			await _context.ReservationDto.AddAsync(dto);
			await _context.SaveChangesAsync();

			return Ok("Rezervasyon eklendi");
		}
	}
}