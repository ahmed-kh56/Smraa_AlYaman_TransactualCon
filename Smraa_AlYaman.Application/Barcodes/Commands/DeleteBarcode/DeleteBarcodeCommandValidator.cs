using FluentValidation;
using Smraa_AlYaman.Application.Barcodes.Commands.DeleteBarcode;

namespace Smraa_AlYaman.Application.Commands.Barcodes.DeleteBarcode
{
    public class DeleteBarcodeCommandValidator:AbstractValidator<DeleteBarcodeCommand>
    {
        public DeleteBarcodeCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Barcode code must be provided.");
            RuleFor(x => x.Code).MaximumLength(128).WithMessage("Barcode code must not exceed 50 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");
        }
    }


}
