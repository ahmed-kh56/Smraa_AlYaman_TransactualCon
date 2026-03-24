using FluentValidation;

namespace Smraa_AlYaman.Application.Prices.Commands.DeleteCustomPrice
{
    public class DeletePriceCommandValidator:AbstractValidator<DeletePriceCommand>
    {
        public DeletePriceCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");

            RuleFor(x => x.BranchId)
                .GreaterThanOrEqualTo(0).WithMessage("Branch Id cant be negative")
                .NotEqual(0).WithMessage("You cant delete the defaultPrice");

        }
    }
}
