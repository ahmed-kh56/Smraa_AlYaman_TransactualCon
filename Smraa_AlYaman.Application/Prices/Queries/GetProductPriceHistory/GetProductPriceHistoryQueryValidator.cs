using FluentValidation;

namespace Smraa_AlYaman.Application.Prices.Queries.GetProductPriceHistory
{
    public class GetProductPriceHistoryQueryValidator : AbstractValidator<GetProductPriceHistoryQuery>
    {
        public GetProductPriceHistoryQueryValidator()
        {
            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("PageSize must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("PageSize cannot exceed 100.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(0).WithMessage("PageNum must be 0 or greater.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).When(x=>x.ProductId.HasValue).WithMessage("Barcode cannot exceed 64 characters.");



        }
    }
}
