using FluentValidation;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.EngName)
                .NotEmpty().WithMessage("English name is required.")
                .MaximumLength(200).WithMessage("English name must not exceed 200 characters.");

            RuleFor(x => x.CatagoryId)
                .GreaterThan(0).WithMessage("Valid Category is required.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0).WithMessage("Valid Brand is required.");

            RuleFor(x => x.ProductGroupId)
                .GreaterThan(0).WithMessage("Valid Product Group is required.");

            RuleFor(x => x.CountryOfOriginId)
                .GreaterThan(0).WithMessage("Valid Country of Origin is required.");




            RuleFor(x => x.ItemTransactionType)
                .Must(x => Enum.IsDefined(typeof(ProductTransactionType), x))
                .WithMessage("Invalid Transaction Type.");

            RuleFor(x => x.ItemReceiptType)
                .Must(x => Enum.IsDefined(typeof(ProductReceiptType), x))
                .WithMessage("Invalid Receipt Type.");

            RuleFor(x => x.State)
                .Must(x => Enum.IsDefined(typeof(ProductState), x))
                .WithMessage("Invalid State value.");

            RuleFor(x => x.MainTax)
                .MaximumLength(100).WithMessage("Main Tax description must not exceed 100 characters.");

            RuleFor(x => x.SubTax)
                .MaximumLength(100).WithMessage("Sub Tax description must not exceed 100 characters.");

            RuleFor(x => x.TotalTaxAmount)
                .GreaterThanOrEqualTo(0).When(x => x.TotalTaxAmount.HasValue)
                .WithMessage("Total Tax Amount cannot be negative.");
        }
    }
}
