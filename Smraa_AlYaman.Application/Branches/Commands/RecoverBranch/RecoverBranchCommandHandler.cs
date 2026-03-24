using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Branches.Commands.RecoverBranch
{
    public class RecoverBranchCommandHandler(
        IBrancheRepository _brancheRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<RecoverBranchCommand, ResultOf<Branch>>
    {
        public async Task<ResultOf<Branch>> Handle(RecoverBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var audit = await _brancheRepository.GetAuditByAuditIdAsync(request.AuditId);
                var branch = await _brancheRepository.GetByIdAsync(audit.EntityId);





                branch!.RecoverSnapShot(audit);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return branch.AsDone();

            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code:ex.Code,description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}
