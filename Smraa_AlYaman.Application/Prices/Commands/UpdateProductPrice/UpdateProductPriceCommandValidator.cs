using FluentValidation;

namespace Smraa_AlYaman.Application.Prices.Commands.UpdateProductPrice
{
    public class UpdateProductPriceCommandValidator : AbstractValidator<UpdateProductPriceCommand>
    {
        public UpdateProductPriceCommandValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0);

            RuleFor(x => x.PricePerSmallistUnit)
                .GreaterThanOrEqualTo(0)
                .When(x => x.PricePerSmallistUnit.HasValue);

            RuleFor(x => x.WholesalePricePerSmallistUnit)
                .GreaterThanOrEqualTo(0)
                .When(x => x.WholesalePricePerSmallistUnit.HasValue);

            RuleFor(x => x.LowestPricePerSmallistUnit)
                .GreaterThanOrEqualTo(0)
                .When(x => x.LowestPricePerSmallistUnit.HasValue);

            RuleFor(x => x.SmallistUnitCost)
                .GreaterThanOrEqualTo(0)
                .When(x => x.SmallistUnitCost.HasValue);

            RuleFor(x => x.TransactionsSammary)
                .MaximumLength(500)
                .When(x => !string.IsNullOrEmpty(x.TransactionsSammary));

            RuleFor(x => x.Notes)
                .MaximumLength(1000)
                .When(x => !string.IsNullOrEmpty(x.Notes));

            RuleFor(x => x.ProductPriceUnits)
                .GreaterThan(0).LessThan(16)
                .When(x => x.ProductPriceUnits.HasValue);



        }
    }
}
