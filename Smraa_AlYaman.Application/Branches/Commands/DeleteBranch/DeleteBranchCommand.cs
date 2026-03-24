using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;

namespace Smraa_AlYaman.Application.Branches.Commands.DeleteBranch
{
    public record DeleteBranchCommand(int Id) : IRequest<ResultOf<Done>>;
}
