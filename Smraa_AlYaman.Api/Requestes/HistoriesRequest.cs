using Smraa_AlYaman.Application.Barcodes.Queries.GetBarcodeHistory;
using Smraa_AlYaman.Application.Prices.Queries.GetPriceHistory;
using Smraa_AlYaman.Application.Products.Queries.GetProductsHistory;

namespace Smraa_AlYaman.Api.Requestes
{
    public class HistoriesRequest
    {
        public int PageSize { get; set; } = 12;
        public int PageNumber { get; set; } = 0;
        //public Including Including { get; set; }


        public GetBarcodeHistoryQuery ToGetBarcodeHistoryQuery(string? code, int? productId)
        {
            //var (update, delete) = GetIncludingFlags();

            return new GetBarcodeHistoryQuery(
                productId,
                code,
                PageSize,
                PageNumber);
        }
        public GetCustomPriceHistoryQuery ToGetCustomPriceHistoryQuery(string code,int BranchId)
        {
            //var (update, delete) = GetIncludingFlags();

            return new GetCustomPriceHistoryQuery(
                code,
                BranchId,
                PageSize,
                PageNumber);
        }
        public GetCustomPriceHistoryQuery ToGetPriceHistoryQuery(string? code,int? branchId)
        {
            //var (update, delete) = GetIncludingFlags();
            return new GetCustomPriceHistoryQuery(
                code,
                branchId,
                PageSize,
                PageNumber);
        }

        public GetProductHistoryQuery ToGetProductHistoryQuery(
            int ? id,
            int? groupId,
            int? brandId,
            int? countryId,
            int? catagoryId,
            int? productState,
            int? receiptType,
            int? transactionType)
        {
            return new GetProductHistoryQuery(
                id,
                PageSize,
                PageNumber,
                groupId,
                countryId,
                brandId,
                catagoryId,
                productState,
                receiptType,
                transactionType);
        }

        //private (bool includeUpdates, bool includeDeletes) GetIncludingFlags()
        //{
        //    return (
        //        Including.HasFlag(Including.Updated),
        //        Including.HasFlag(Including.Deleted)
        //    );
        //}


    }

    [Flags]
    public enum Including
    {
        None = 0,
        Updated = 1,
        Deleted = 2,
        All = Updated | Deleted
    }


}
