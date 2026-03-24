using FluentValidation;
using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Barcodes.Commands.RecoverBarcode;

public record RecoverBarcodeCommand(Guid AuditId):IRequest<ResultOf<Barcode>>;

public class RecoverCustomPriceCommandValidator : AbstractValidator<RecoverBarcodeCommand>
{
    public RecoverCustomPriceCommandValidator()
    {
        RuleFor(x => x.AuditId)
            .NotEmpty()
            .NotEqual(Guid.Empty)
            .WithMessage("AuditId is required.");
    }
}
