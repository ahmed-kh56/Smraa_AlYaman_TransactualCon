using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;

namespace Smraa_AlYaman.Application.Branches.Commands.CreateBranch
{
    public record CreateBranchCommand(
        string BranchName,
        string? BranchAddress = null,
        string? BranchPhone = null)
        : IRequest<ResultOf<Branch>>;
}
