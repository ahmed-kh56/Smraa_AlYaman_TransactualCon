using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.UpdateSupplyer
{
    public record UpdateSupplayerCommand(int Id, string? Name = null, string? Phone = null, int? Scope = null) : IRequest<ResultOf<Supplayer>>;
}
