using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;

namespace Smraa_AlYaman.Application.Availablty.Commands.ChangeProductAvailablty
{
    public class ChangeProductAvailabltyCommandHandler(
        IAvailabltyRepository _availabltyRepository,
        IProductRepository _productRepository,
        IBrancheRepository _brancheRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<ChangeProductAvailabltyCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(ChangeProductAvailabltyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var BIds = request.ChangeDtos.Select(dto => dto.BrancheId).ToList();
                var PId = request.ChangeDtos.First().ProductId;

                var Product = await _productRepository.GetByIdAsync(PId);
                if (Product is null)
                {
                    return Error.Conflict(
                        code: "ChangeProductAvailablty_ProductNotFound",
                        description: $"Product with id '{PId}' was not found.");
                }

                var Branches = await _brancheRepository.GetBranchesAsync(BIds);
                if (!Branches.Any())
                {
                    return Error.Conflict(
                        code: "ChangeProductAvailablty_BranchesNotFound",
                        description: "Branches were not found.");
                }


                var existingAvailabilities = await _availabltyRepository
                    .GetByBranchIdOnProductIdAsync(BIds, PId);

                var existingDict = existingAvailabilities.ToDictionary(x => x.BrancheId);


                Product.ReassignActivationState(
                    changes: request.ChangeDtos.Select(
                        c => new BranchState
                        {
                            Id = c.BrancheId,
                            ProductId= c.ProductId,
                            Activateing = c.Activateing
                        })
                    .ToList(),
                    existingDict: existingDict,
                    out var toAdd,
                    out var toDelete);

                await _unitOfWork.StartTransactionAsync();


                await _availabltyRepository.AddRangeAsync(toAdd);

                await _availabltyRepository.DeleteRangeAsync(toDelete);

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
                return Done.done.AsDone();
            }
            catch (DomainException ex)
            {
                return Error.DomainFailure(code: ex.Code, description: ex.Message);
            }
            catch (Exception ex)
            {
                return Error.Failure(code: "ChangeProductAvailablty_Failure", description: ex.Message);
            }
        }

    }
}
