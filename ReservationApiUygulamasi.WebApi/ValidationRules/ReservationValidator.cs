using FluentValidation;
using ReservationApiUygulamasi.EL.ApiModels;

namespace ReservationApiUygulamasi.WebApi.ValidationRules
{
	public class ReservationValidator : AbstractValidator<CreateReservationDto>
	{
		public ReservationValidator()
		{
			RuleFor(x => x.ProductRef).NotEmpty().WithMessage("ProductRef boş olamaz.")
									.GreaterThan(0).WithMessage("ProductRef boş olamaz.");
			RuleFor(x => x.ReservedQty).GreaterThan(0).WithMessage("ReservedQty sıfırdan büyük olmalıdır.");
			RuleFor(x => x.Notes).MaximumLength(500).WithMessage("Notes 500 karakteri geçemez.");
		}
	}
}
