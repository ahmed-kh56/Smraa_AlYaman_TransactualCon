using FluentValidation;
using MediatR;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Barcodes.Commands.CreateBarcode
{
    public class CreateBarcodeCommandValidator : AbstractValidator<CreateBarcodeCommand>
    {
        public CreateBarcodeCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required.")
                .NotEqual(0).WithMessage("Product Id cannot be empty.");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Barcode code is required.")
                .MaximumLength(100).WithMessage("Barcode code cannot exceed 100 characters.");

            RuleFor(x => x.Code).Matches("^[0-9]+$").WithMessage("Barcode code must be alphanumeric.");


            RuleFor(x => x.Unit)
                .Must( x=> Enum.IsDefined(typeof(BarcodePricingUnit), x))
                .WithMessage("Invalid unit value.");

            RuleFor(x => x.UnitsCountPerPackage)
                .GreaterThan(0).WithMessage("Units count per package must be greater than 0.");



            RuleFor(x => x.UnitsCountPerPackage)
                .GreaterThan(0).WithMessage("Smallest unit price must be greater than 0.");


            RuleFor(x => x.Type)
                .Must(value => Enum.IsDefined(typeof(BarcodeType), value))
                .WithMessage("Invalid BarcodeType");

            RuleFor(x => x.Unit)
                .Must(value => Enum.IsDefined(typeof(BarcodePricingUnit), value))
                .WithMessage("Invalid BarcodePricingUnit");

            RuleFor(x => x.Size)
                .Must(value => !value.HasValue || Enum.IsDefined(typeof(BarcodeSize), value.Value))
                .WithMessage("Invalid BarcodeSize");






        }
    }

}
