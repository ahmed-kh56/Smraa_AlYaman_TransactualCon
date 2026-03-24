using Smraa_AlYaman.Application.Products.Queries.GetProductsHistory;

namespace Smraa_AlYaman.Api.Requestes
{
    public class ProductHistoryRequest
    {
        public int PageSize { get; set; } = 12;
        public int PageNumber { get; set; } = 0;
        //public Including Including { get; set; }

        public int? GroupId { get; set; }
        public int? BrandId { get; set; }
        public int? CountryId { get; set; }
        public int? CatagoryId { get; set; }
        public int? ProductState { get; set; }
        public int? ReceiptType { get; set; }
        public int? TransactionType { get; set; }

        public GetProductHistoryQuery ToQuery(int? productId)
        {
            //var (update, delete) = (
            //    Including.HasFlag(Including.Updated),
            //    Including.HasFlag(Including.Deleted)
            //);

            return new GetProductHistoryQuery(
                productId,
                PageSize,
                PageNumber,
                GroupId,
                CountryId,
                BrandId,
                CatagoryId,
                ProductState,
                ReceiptType,
                TransactionType);
        }
    }


}
