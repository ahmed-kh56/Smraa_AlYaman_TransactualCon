using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Application.Supplayers.Commands.CreateSupplyer;

public record CreateSupplayerCommand(string Name, string Phone, int Scope):IRequest<ResultOf<Supplayer>>;
