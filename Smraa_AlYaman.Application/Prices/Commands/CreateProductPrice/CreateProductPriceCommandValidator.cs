using FluentValidation;

namespace Smraa_AlYaman.Application.Prices.Commands.CreateProductPrice
{
    public class CreateProductPriceCommandValidator : AbstractValidator<CreateProductPriceCommand>
    {
        public CreateProductPriceCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.PricePerSmallistUnit)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.WholesalePricePerSmallistUnit)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(x => x.PricePerSmallistUnit)
                .WithMessage("Wholesale price cannot be greater than the normal price.");

            RuleFor(x => x.LowestPricePerSmallistUnit)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(x => x.PricePerSmallistUnit)
                .WithMessage("Lowest price cannot be greater than the normal price.");

            RuleFor(x => x.SmallistUnitCost)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.ProductPriceUnits)
                .NotNull();

            RuleFor(x => x.TransactionsSammary)
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.ProductPriceUnits)
                .GreaterThan(0)
                .LessThan(16);

            RuleFor(x => x.Notes)
                .MaximumLength(1000);

            RuleFor(x => x)
                .Must(x => x.LowestPricePerSmallistUnit <= x.PricePerSmallistUnit)
                .WithMessage("Lowest price must be less than or equal to the normal price.");

            RuleFor(x => x)
                .Must(x => x.WholesalePricePerSmallistUnit <= x.PricePerSmallistUnit)
                .WithMessage("Wholesale price must be less than or equal to the normal price.");
        }
    }

}