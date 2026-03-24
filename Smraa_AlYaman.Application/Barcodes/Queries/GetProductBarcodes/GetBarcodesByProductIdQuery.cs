using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Application.Barcodes.Queries.GetProductBarcodes;

public record GetBarcodesByProductIdQuery(int ProductId):IRequest<ResultOf<IEnumerable<Barcode>>>;

