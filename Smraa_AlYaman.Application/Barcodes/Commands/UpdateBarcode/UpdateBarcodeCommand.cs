using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Commands.Barcodes.UpdateBarcode;

public record UpdateBarcodeCommand(
    string Code,
    decimal? UnitsCountPerPackage,
    bool? IsActive,
    int? Type,
    int? Size,
    int? Unit,
    bool? IsAllowedOnline,
    string? Notes
) : IRequest<ResultOf<Barcode>>;
