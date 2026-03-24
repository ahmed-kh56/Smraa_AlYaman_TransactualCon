using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.ProductSuppliers;

namespace Smraa_AlYaman.Application.ProductSupplayers.Commands.CreateProductSupplayer
{
    public class CreateProductSupplayerCommandHandler(
        IProductRepository _productRepository,
        IProductSupplayerRepository _productSupplayerRepository,
        ISupplayerRepository _supplierRepository,
        IUnitOfWork _unitOfWork)
        : IRequestHandler<CreateProductSupplayerCommand, ResultOf<ProductSupplayer>>
    {
        public async Task<ResultOf<ProductSupplayer>> Handle(CreateProductSupplayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.ProductId);
                if (product == null)
                {
                    return Error.NotFound(
                        code: "CreateProductSupplayerCommandHandler_ProductNotFound",
                        description: $"Product with ID {request.ProductId} was not found.");
                }

                var supplayer = await _supplierRepository.GetByIdAsync(request.SupplayerId);
                if (supplayer == null)
                {
                    return Error.NotFound(
                        code: "CreateProductSupplayerCommandHandler_SupplayerNotFound",
                        description: $"Supplayer with ID {request.SupplayerId} was not found.");
                }

                var existing = await _productSupplayerRepository
                    .GetByIdsAsync(request.ProductId, request.SupplayerId, true);

                if (existing != null)
                {
                    if (!existing.IsDeleted)
                    {
                        return Error.Conflict(
                            code: "CreateProductSupplayerCommandHandler_AlreadyExists",
                            description: "Product already linked to this supplier.");
                    }

                    existing.Recover();

                    await _unitOfWork.SaveChangesAsync();

                    return existing.AsDone();
                }

                var productSupplayer = new ProductSupplayer(request.ProductId, request.SupplayerId);

                await _productSupplayerRepository.AddAsync(productSupplayer);

                await _unitOfWork.SaveChangesAsync();

                return productSupplayer.AsCreated();
            }
            catch (Exception ex)
            {
                return Error.Failure(
                    code: "CreateProductSupplayerCommandHandler_FailedToCreateProductSupplayer",
                    description: ex.Message);
            }
        }
    }

}
