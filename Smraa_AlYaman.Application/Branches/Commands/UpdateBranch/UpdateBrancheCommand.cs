using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;

namespace Smraa_AlYaman.Application.Branches.Commands.UpdateBranch
{
    public record UpdateBrancheCommand(
        int Id,
        string? Name = null,
        string? Address = null,
        string? Phone = null) : IRequest<ResultOf<Branch>>;

}
