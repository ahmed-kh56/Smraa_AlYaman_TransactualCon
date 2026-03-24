using FluentValidation;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Queries.GetProductsHistory
{
    public class GetProductHistoryQueryValidator : AbstractValidator<GetProductHistoryQuery>
    {
        public GetProductHistoryQueryValidator()
        {
            RuleFor(x => x.PageSize)
                .GreaterThan(0).WithMessage("PageSize must be greater than 0.")
                .LessThanOrEqualTo(100).WithMessage("PageSize cannot exceed 100.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(0).WithMessage("PageNum must be 0 or greater.");

            RuleFor(x => x.Id)
                .NotEmpty().When(x => x.Id.HasValue)
                .WithMessage("Id cannot be empty if provided.");


            RuleFor(x => x.TransactionType)
                .Must(x => Enum.IsDefined(typeof(ProductTransactionType), x))
                .When(x => x.TransactionType.HasValue)
                .WithMessage("Invalid Transaction Type.");

            RuleFor(x => x.ReceiptType)
                .Must(x => Enum.IsDefined(typeof(ProductReceiptType), x))
                .When(x => x.ReceiptType.HasValue)
                .WithMessage("Invalid Receipt Type.");

            RuleFor(x => x.ProductState)
                .Must(x => Enum.IsDefined(typeof(ProductState), x))
                .When(x => x.ProductState.HasValue)
                .WithMessage("Invalid State value.");




            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("PageSize must be greater than 0.")
                .LessThanOrEqualTo(100)
                .WithMessage("PageSize cannot exceed 100.");

            RuleFor(x => x.PageNum)
                .GreaterThanOrEqualTo(0)
                .WithMessage("PageNum must be 0 or greater.");

            // Optional Id (لو موجود يبقى > 0)
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .When(x => x.Id.HasValue)
                .WithMessage("Id must be greater than 0 if provided.");


            // Filters (لو اتبعت تبقى > 0)
            RuleFor(x => x.GroupId)
                .GreaterThan(0)
                .When(x => x.GroupId.HasValue)
                .WithMessage("GroupId must be greater than 0.");

            RuleFor(x => x.CountryOfOriginId)
                .GreaterThan(0)
                .When(x => x.CountryOfOriginId.HasValue)
                .WithMessage("CountryOfOriginId must be greater than 0.");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .When(x => x.BrandId.HasValue)
                .WithMessage("BrandId must be greater than 0.");

            RuleFor(x => x.CatagoryId)
                .GreaterThan(0)
                .When(x => x.CatagoryId.HasValue)
                .WithMessage("CatagoryId must be greater than 0.");

            RuleFor(x => x.ProductState)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ProductState.HasValue)
                .WithMessage("ProductState must be valid.");

            RuleFor(x => x.ReceiptType)
                .GreaterThanOrEqualTo(0)
                .When(x => x.ReceiptType.HasValue)
                .WithMessage("ReceiptType must be valid.");

            RuleFor(x => x.TransactionType)
                .GreaterThanOrEqualTo(0)
                .When(x => x.TransactionType.HasValue)
                .WithMessage("TransactionType must be valid.");


        }
    }
}
