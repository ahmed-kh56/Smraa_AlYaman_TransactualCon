using MediatR;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int ProductId) : IRequest<ResultOf<Done>>;
