using MediatR;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Barcodes.Commands.DeleteBarcode;

public record DeleteBarcodeCommand(string Code):IRequest<ResultOf<Done>>;
