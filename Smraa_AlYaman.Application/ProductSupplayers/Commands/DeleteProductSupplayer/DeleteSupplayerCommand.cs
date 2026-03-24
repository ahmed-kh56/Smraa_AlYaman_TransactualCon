using MediatR;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.DeleteProductSupplayer;

public record DeleteProductSupplayerCommand(int? SupplayerId,int? ProductId):IRequest<ResultOf<Done>>;
