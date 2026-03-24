using MediatR;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Branchs.Audits;

namespace Smraa_AlYaman.Application.Branches.Commands.RecoverBranch
{
    public record RecoverBranchCommand(Guid AuditId):IRequest<ResultOf<Branch>>;
}
