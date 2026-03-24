using FluentValidation;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.UpdateSupplyer
{
    public class UpdateSupplayerCommandValidator : AbstractValidator<UpdateSupplayerCommand>
    {
        public UpdateSupplayerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");
            RuleFor(x => x.Phone)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(x => x.Phone is not null)
                .WithMessage("Phone must be a valid international phone number.");
            RuleFor(x => x.Scope)
                .Must(x => Enum.IsDefined(typeof(SupplayerScope), x))
                .WithMessage("Scope must be a valid enum value.").When(x=>x.Scope.HasValue);
        }
    }
}
