using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;

namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //EKLE HEPSİNE CUNKU token girmeden İŞLEM YAPMASINA izin vermesin .
	public class UsersController : ControllerBase
	{
		private readonly ApiContext _context;

		public UsersController()
		{
			_context = new ApiContext();
		}


		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetAllUser()
		{
			if (_context.UserDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null."); //NUL Referencess Hatası için .

			var values = await _context.UserDto.ToListAsync();
			return Ok(values);
		}


		[HttpPost]
		public async Task<IActionResult> InsertUser([FromBody] UserDto dto)
		{
			if (_context.UserDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null.");

			await _context.UserDto.AddAsync(dto);
			await _context.SaveChangesAsync();

			return Ok("Rezervasyon eklendi");
		}

	}
}
