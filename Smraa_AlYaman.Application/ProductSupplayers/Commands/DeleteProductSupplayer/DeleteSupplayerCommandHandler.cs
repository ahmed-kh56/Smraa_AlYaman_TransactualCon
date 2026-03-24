using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.DeleteProductSupplayer
{
    public class DeleteProductSupplayerCommandHandler(
        IProductSupplayerRepository _productSupplierRepository,
        IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteProductSupplayerCommand, ResultOf<Done>>
    {
        public async Task<ResultOf<Done>> Handle(DeleteProductSupplayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var productSupplayeres = await _productSupplierRepository.GetAllByProductIdAndSupplayerId(request.ProductId, request.SupplayerId);

                if (!productSupplayeres.Any())
                {
                    return Error.NotFound(
                        code: "DeleteProductSupplayerCommandHandler_ProductSupplayerNotFound",
                        description: $"Supplayers was not found.");
                }

                foreach (var productSupplayer in productSupplayeres)
                {
                    productSupplayer.MarkAsDeleted();
                }

                await _productSupplierRepository.UpdateBulkAsync(productSupplayeres);
                await unitOfWork.SaveChangesAsync(cancellationToken);

                return Done.done.AsNoContent();

            }
            catch (Exception ex)
            {
                return Error.Failure(
                    description: ex.Message,
                    code: "DeleteProductSupplayerCommandHandler_Failure");
            }
        }
    }
}
