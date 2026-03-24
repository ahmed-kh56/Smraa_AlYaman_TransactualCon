using FluentValidation;

namespace Smraa_AlYaman.Application.Supplayers.Commands.DeleteSupplayer
{
    public class DeleteSupplayerCommandValidator : AbstractValidator<DeleteSupplayerCommand>
    {
        public DeleteSupplayerCommandValidator()
        {
            RuleFor(x => x.SupplayerId).GreaterThan(0);
        }
    }
}
