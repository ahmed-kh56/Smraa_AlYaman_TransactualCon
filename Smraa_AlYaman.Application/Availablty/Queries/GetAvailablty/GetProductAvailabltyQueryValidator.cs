using FluentValidation;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailablty;

public class GetProductAvailabltyQueryValidator : AbstractValidator<GetProductAvailabltyQuery>
{
    public GetProductAvailabltyQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
    }
}
