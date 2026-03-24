using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductSuppliers;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.CreateProductSupplayer;

public record CreateProductSupplayerCommand(int ProductId, int SupplayerId):IRequest<ResultOf<ProductSupplayer>>;
