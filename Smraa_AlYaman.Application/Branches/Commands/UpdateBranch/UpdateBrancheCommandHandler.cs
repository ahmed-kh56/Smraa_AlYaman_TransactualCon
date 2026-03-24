using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Branches.Commands.UpdateBranch
{
    public class UpdateBrancheCommandHandler(
        IBrancheRepository _brancheRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<UpdateBrancheCommand, ResultOf<Branch>>
    {
        public async Task<ResultOf<Branch>> Handle(UpdateBrancheCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = await _brancheRepository.GetByIdAsync(request.Id);
                if (branch == null)
                {
                    return Error.NotFound();
                }

                branch.Update(
                    request.Name,
                    request.Phone,
                    request.Address);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return branch.AsDone();
            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}
