using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes.Audits;

namespace Smraa_AlYaman.Application.Barcodes.Queries.GetBarcodeHistory
{
    public record GetBarcodeHistoryQuery(
        int? ProductId,
        string? Barcode,
        int PageSize,
        int PageNum)
        :IRequest<ResultOf<IEnumerable<BarcodeAudit>>>;


}
