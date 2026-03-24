using FluentValidation;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Commands.Barcodes.UpdateBarcode
{
    public class UpdateBarcodeCommandValidator : AbstractValidator<UpdateBarcodeCommand>
    {
        public UpdateBarcodeCommandValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");
            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");



            RuleFor(x => x.UnitsCountPerPackage)
                .GreaterThan(0)
                .When(x => x.UnitsCountPerPackage.HasValue)
                .WithMessage("Units count per package must be greater than 0.");


            RuleFor(x => x.Type)
                .Must(value => !value.HasValue || Enum.IsDefined(typeof(BarcodeType), value))
                .WithMessage("Invalid BarcodeType");

            RuleFor(x => x.Unit)
                .Must(value => !value.HasValue || Enum.IsDefined(typeof(BarcodePricingUnit), value))
                .WithMessage("Invalid BarcodePricingUnit");

            RuleFor(x => x.Size)
                .Must(value => !value.HasValue || Enum.IsDefined(typeof(BarcodeSize), value.Value))
                .WithMessage("Invalid BarcodeSize");

        }
    }

}
