using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Branches.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler(
        IBrancheRepository _brancheRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<DeleteBranchCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(request.Id == 0)
                    return Error.Validation(
                        code:"DeleteBranchCommandHandler.Handle_Validation",
                        description:"BranchId Can't Equel 0 or be empty");

                var branch = await _brancheRepository.GetByIdAsync(request.Id);
                if (branch == null)
                    return Error.NotFound(
                        code: "DeleteBranchCommandHandler.Handle_NotFound",
                        description: $"the branch with id: {request.Id} hasn't been found ");

                branch.MarkAsDeleted();

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Done.done.AsNoContent();

            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(description: ex.Message);
            }
        }
    }
}
