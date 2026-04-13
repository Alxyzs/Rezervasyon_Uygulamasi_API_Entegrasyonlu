using FluentValidation;
using ReservationApiUygulamasi.EL.ApiModels;

namespace ReservationApiUygulamasi.WebApi.ValidationRules
{
	public class ProductValidator:AbstractValidator<ProductDto>
	{
		public ProductValidator()
		{
			
		}
	}
}
