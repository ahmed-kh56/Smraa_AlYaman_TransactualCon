using FluentValidation;

namespace Smraa_AlYaman.Application.Availablty.Queries.GetAvailabltyhistory;

public class GetAvailabltyHiestoryQueryValidator : AbstractValidator<GetAvailabltyHiestoryQuery>
{
    public GetAvailabltyHiestoryQueryValidator()
    {
        RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0");
        RuleFor(x => x.BranchId).GreaterThan(0).When(x => x.BranchId.HasValue).WithMessage("BranchId must be greater than 0");
    }
}