using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;

namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize] //Sadece Auth olan kullanıcı erişebilir .
	public class ProductsController : ControllerBase
	{
		private readonly ApiContext _context;

		public ProductsController()
		{
			_context = new ApiContext();
		}

		[HttpGet]
		public async Task<ActionResult<List<ProductDto>>> GetAll()
		{
			if (_context.ProductDto == null)
				return Problem(" 'ApiContext.ReservationDto'  is null."); //NUL Referencess Hatası için .

			var values = await _context.ProductDto.Where(x => x.StockQuantity > 0).ToListAsync();
			return Ok(values);
		}
	}
}