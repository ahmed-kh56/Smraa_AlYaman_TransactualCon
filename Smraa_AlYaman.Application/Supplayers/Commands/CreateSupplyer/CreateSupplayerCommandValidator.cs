using FluentValidation;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.CreateSupplyer
{
    public class CreateSupplayerCommandValidator: AbstractValidator<CreateSupplayerCommand>
    {
        public CreateSupplayerCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(120).MinimumLength(3);
            RuleFor(x => x.Phone).NotEmpty().MaximumLength(30).MinimumLength(11);
            RuleFor(x => x.Scope).Must(v=>Enum.IsDefined(typeof(SupplayerScope),v));
        }
    }
}
