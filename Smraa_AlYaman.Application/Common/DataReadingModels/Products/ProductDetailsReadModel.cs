using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData
{

    public class ProductDetailsModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductEnglishName { get; set; }

        public ProductState State { get; set; }
        public bool IsAllowedOnline { get; set; }

        public ProductTransactionType TransactionType { get; set; }
        public ProductReceiptType ReceiptType { get; set; }

        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public string? MainTax { get; set; }

        public string? SubTax { get; set; }
        public decimal? TotalTaxes { get; set; }

        public ProductPriceData? PriceData { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
