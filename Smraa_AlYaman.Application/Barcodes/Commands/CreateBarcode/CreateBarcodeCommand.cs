using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Barcodes.Commands.CreateBarcode
{
    public record CreateBarcodeCommand(
        int ProductId,
        string Code,
        int Type,
        int Unit,
        decimal UnitsCountPerPackage,
        bool IsActive,
        bool IsAllowedOnline,
        string? Notes = null,
        int? Size = null
    ) : IRequest<ResultOf<Barcode>>;




}
