using FluentValidation;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.DeleteProductSupplayer
{
    public class DeleteProductSupplayerCommandValidator : AbstractValidator<DeleteProductSupplayerCommand>
    {
        public DeleteProductSupplayerCommandValidator()
        {
            RuleFor(x => x.SupplayerId).GreaterThan(0).When(x=>x.SupplayerId.HasValue);
            RuleFor(x => x.SupplayerId).GreaterThan(0).When(x=>x.ProductId.HasValue);
        }
    }
}
