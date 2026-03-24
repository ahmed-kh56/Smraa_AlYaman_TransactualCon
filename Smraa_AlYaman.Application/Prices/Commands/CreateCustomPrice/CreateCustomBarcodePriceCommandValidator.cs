using FluentValidation;


namespace Smraa_AlYaman.Application.Prices.Commands.CreateCustomPrice
{
    public class CreateCustomBarcodePriceCommandValidator:AbstractValidator<CreateCustomBarcodePriceCommand>
    {
        public CreateCustomBarcodePriceCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");


            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.LowistPrice)
                .GreaterThan(0)
                .When(x => x.LowistPrice.HasValue)
                .WithMessage("Lowest price must be greater than 0.");
            RuleFor(x => x.BranchId)
                .GreaterThan(0).WithMessage("Branch Id must be greater than 0 Becous 0 is the default branch");
        }
    }


}
