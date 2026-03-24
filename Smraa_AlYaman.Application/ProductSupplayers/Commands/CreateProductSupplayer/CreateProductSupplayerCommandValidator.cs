using FluentValidation;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.CreateProductSupplayer
{
    public class CreateProductSupplayerCommandValidator:AbstractValidator<CreateProductSupplayerCommand>
    {
        public CreateProductSupplayerCommandValidator()
        {

            RuleFor(x => x.ProductId).GreaterThan(0);
            RuleFor(x => x.SupplayerId).GreaterThan(0);

        }
    }
}
