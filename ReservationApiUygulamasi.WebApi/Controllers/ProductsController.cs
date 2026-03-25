using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationApiUygulamasi.EL.ApiModels;
using ReservationApiUygulamasi.WebApi.Context;

namespace ReservationApiUygulamasi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
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
			var values = await _context.ProductDto.ToListAsync();
			return Ok(values);
		}
	}
}