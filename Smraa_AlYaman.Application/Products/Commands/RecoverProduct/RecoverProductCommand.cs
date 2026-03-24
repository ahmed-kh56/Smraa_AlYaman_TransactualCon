using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.RecoverProduct;

public record RecoverProductCommand(Guid AuditId) :IRequest<ResultOf<Product>>;
