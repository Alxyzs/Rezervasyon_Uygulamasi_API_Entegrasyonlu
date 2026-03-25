using Microsoft.AspNetCore.Mvc;
using ReservationApiUygulamasi.WebApi.Context;
using ReservationApiUygulamasi.EL.ApiModels;

namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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