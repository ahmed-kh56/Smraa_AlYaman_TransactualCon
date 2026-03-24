using FluentValidation;

namespace Smraa_AlYaman.Application.Prices.Queries.GetAllCustomPrices;

public class GetAllCustomPricesQueryValidator : AbstractValidator<GetAllCustomPricesQuery>
{
    public GetAllCustomPricesQueryValidator()
    {
        RuleFor(q=> q.Code)
            .Matches("^[0-9]+$")
            .When(q=> !string.IsNullOrEmpty(q.Code))
            .WithMessage("Barcode code must be alphanumeric.");

        RuleFor(q=> q.BranchId)
            .GreaterThan(0).When(q=> q.BranchId.HasValue)
            .WithMessage("BranchId must be greater than 0.");

        RuleFor(q=> q.ProductId)
            .GreaterThan(0).When(q=> q.ProductId.HasValue)
            .WithMessage("ProductId must be greater than 0.");


        RuleFor(q => q)
            .Must(q => q.Code != null || q.BranchId != null || q.ProductId != null)
            .WithMessage("Can't get a prices with no data sended.");

    }
}
