using Smraa_AlYaman.Application.Products.Commands.CreateProduct;

namespace Smraa_AlYaman.Api.Requestes
{

    public class ProductCreateRequest
    {
        public string Name { get; set; } = null!;
        public string EngName { get; set; } = null!;

        public int ItemTransactionType { get; set; }
        public int ItemReceiptType { get; set; }

        public int CatagoryId { get; set; }
        public int BrandId { get; set; }
        public int ProductGroupId { get; set; }
        public int CountryOfOriginId { get; set; }

        public string? MainTax { get; set; }
        public string? SubTax { get; set; }
        public decimal? TotalTaxAmount { get; set; }

        public int State { get; set; } = 1;
        public bool IsAllowedOnline { get; set; } = true;

        public CreateProductCommand ToCommand()
            => new(
                Name,
                EngName,
                ItemTransactionType,
                ItemReceiptType,
                CatagoryId,
                BrandId,
                ProductGroupId,
                CountryOfOriginId,
                MainTax,
                SubTax,
                TotalTaxAmount,
                State,
                IsAllowedOnline
            );
    }

}






