using FluentValidation;

namespace Smraa_AlYaman.Application.Branches.Commands.CreateBranch
{


    public class CreateBrancheCommandValidator : AbstractValidator<CreateBranchCommand>
    {
        public CreateBrancheCommandValidator()
        {
            RuleFor(x => x.BranchName).NotEmpty();
            RuleFor(x => x.BranchName).MaximumLength(60).When(n => n.BranchName is not null).MinimumLength(5).When(n => n.BranchName is not null);
            RuleFor(x => x.BranchAddress).MaximumLength(500).When(n => n.BranchAddress is not null).MinimumLength(15).When(n => n.BranchAddress is not null);
            RuleFor(x => x.BranchAddress).Must(n => String.IsNullOrEmpty(n)).When(n => n.BranchAddress is not null);
            RuleFor(x => x.BranchPhone).Must(n => String.IsNullOrEmpty(n)).When(n => n.BranchPhone is not null);
            RuleFor(x => x.BranchPhone).MaximumLength(30).When(x => x.BranchPhone is not null).MinimumLength(11).When(x => x.BranchPhone is not null);
            RuleFor(x => x.BranchPhone)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => x.BranchPhone is not null).WithMessage("Phone must be a valid international phone number.");

        }
    }

}
