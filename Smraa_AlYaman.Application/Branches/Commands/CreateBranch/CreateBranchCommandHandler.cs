using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Branchs;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Branches.Commands.CreateBranch
{
    public class CreateBranchCommandHandler(
        IBrancheRepository _brancheRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateBranchCommand, ResultOf<Branch>>
    {
        public async Task<ResultOf<Branch>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var branch = new Branch(
                    request.BranchName,
                    request.BranchPhone,
                    request.BranchAddress);

                await _brancheRepository.AddAsync(branch);
                await _unitOfWork.SaveChangesAsync(cancellationToken);


                return branch.AsCreated();

            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Unexpected(code: "CreateBranchCommandHandler.Handle_Unexpected", description: ex.Message);
            }
        }
    }
}
