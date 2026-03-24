using Smraa_AlYaman.Application.Products.Commands.UpdateProduct;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Api.Requestes
{

    public class ProductUpdateRequest
    {
        public string? Name { get; set; }
        public string? EngName { get; set; }

        public int? ItemTransactionType { get; set; }
        public int? ItemReceiptType { get; set; }

        public int? CatagoryId { get; set; }
        public int? BrandId { get; set; }
        public int? ProductGroupId { get; set; }
        public int? CountryOfOriginId { get; set; }

        public string? MainTax { get; set; }
        public string? SubTax { get; set; }
        public decimal? TotalTaxAmount { get; set; }

        public int? State { get; set; }
        public bool? IsAllowedOnline { get; set; }

        public UpdateProductCommand ToCommand(int id)
            => new(
                id,
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






