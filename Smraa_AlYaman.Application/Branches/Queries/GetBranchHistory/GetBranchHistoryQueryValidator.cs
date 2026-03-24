using FluentValidation;

namespace Smraa_AlYaman.Application.Branches.Queries.GetBranchHistory
{
    public class GetBranchHistoryQueryValidator : AbstractValidator<GetBranchHistoryQuery>
    {
        public GetBranchHistoryQueryValidator()
        {
            RuleFor(x=>x.BranchId).GreaterThanOrEqualTo(1).When(x=>x.BranchId.HasValue);
            RuleFor(x =>x.Page).GreaterThanOrEqualTo(0);
            RuleFor(x =>x.PageSize).GreaterThanOrEqualTo(6);
        }
    }
}
