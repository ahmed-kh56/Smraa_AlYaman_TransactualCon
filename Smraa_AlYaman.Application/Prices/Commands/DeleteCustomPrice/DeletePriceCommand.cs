using MediatR;
using Smraa_AlYaman.Common.ResultOf;


namespace Smraa_AlYaman.Application.Prices.Commands.DeleteCustomPrice;

public record DeletePriceCommand(string Code, int BranchId):IRequest<ResultOf<Done>>;
