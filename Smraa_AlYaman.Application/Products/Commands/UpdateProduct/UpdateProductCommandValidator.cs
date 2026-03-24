using FluentValidation;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Product ID is required.")
                .GreaterThan(0).WithMessage("Invalid product ID.");

            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.")
                .When(x => x.Name != null);

            RuleFor(x => x.EngName)
                .MaximumLength(200).WithMessage("English name must not exceed 200 characters.")
                .When(x => x.EngName != null);

            RuleFor(x => x.CatagoryId).GreaterThan(0).When(x => x.CatagoryId.HasValue);
            RuleFor(x => x.BrandId).GreaterThan(0).When(x => x.BrandId.HasValue);
            RuleFor(x => x.ProductGroupId).GreaterThan(0).When(x => x.ProductGroupId.HasValue);
            RuleFor(x => x.CountryOfOriginId).GreaterThan(0).When(x => x.CountryOfOriginId.HasValue);

            RuleFor(x => x.ItemTransactionType)
                .Must(x => Enum.IsDefined(typeof(ProductTransactionType), x))
                .When(x => x.ItemTransactionType.HasValue)
                .WithMessage("Invalid Transaction Type.");

            RuleFor(x => x.ItemReceiptType)
                .Must(x => Enum.IsDefined(typeof(ProductReceiptType), x))
                .When(x => x.ItemReceiptType.HasValue)
                .WithMessage("Invalid Receipt Type.");

            RuleFor(x => x.State)
                .Must(x => Enum.IsDefined(typeof(ProductState), x))
                .When(x => x.State.HasValue)
                .WithMessage("Invalid State value.");

            RuleFor(x => x.TotalTaxAmount)
                .GreaterThanOrEqualTo(0)
                .When(x => x.TotalTaxAmount.HasValue);

            RuleFor(x => x.MainTax)
                .MaximumLength(100)
                .When(x => x.MainTax != null);

            RuleFor(x => x.SubTax)
                .MaximumLength(100)
                .When(x => x.MainTax != null);
        }
    }

}
