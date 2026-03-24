using FluentValidation;

namespace Smraa_AlYaman.Application.Branches.Commands.UpdateBranch
{
    public class UpdateBrancheCommandValidator : AbstractValidator<UpdateBrancheCommand>
    {
        public UpdateBrancheCommandValidator()
        {
            RuleFor(x => x.Name).Must(n => String.IsNullOrEmpty(n)).When(n => n.Name is not null);
            RuleFor(x => x.Name).MaximumLength(60).When(n => n.Name is not null).MinimumLength(5).When(n => n.Name is not null);
            RuleFor(x => x.Address).MaximumLength(500).When(n => n.Address is not null).MinimumLength(15).When(n => n.Address is not null);
            RuleFor(x => x.Address).Must(n => String.IsNullOrEmpty(n)).When(n => n.Address is not null);
            RuleFor(x => x.Phone).Must(n => String.IsNullOrEmpty(n)).When(n => n.Phone is not null);
            RuleFor(x => x.Phone).MaximumLength(30).When(x => x.Phone is not null).MinimumLength(11).When(x => x.Phone is not null);
            RuleFor(x => x.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$").When(x => x.Phone is not null).WithMessage("Phone must be a valid international phone number.");

        }
    }
}
