using FluentValidation;
using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.RecoverCustomPrice;

public record RecoverCustomPriceCommand(Guid AuditId) : IRequest<ResultOf<CustomPrice>>;
public class RecoverCustomPriceCommandValidator : AbstractValidator<RecoverCustomPriceCommand>
{
    public RecoverCustomPriceCommandValidator()
    {
        RuleFor(x => x.AuditId)
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .WithMessage("AuditId is required.");
    }
}
