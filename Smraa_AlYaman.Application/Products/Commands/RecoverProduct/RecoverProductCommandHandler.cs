using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Application.Products.Commands.RecoverProduct
{
    public class RecoverProductCommandHandler(
        IProductRepository _productRepository,
        IProductGroupRepository _productGroupRepository,
        IBrandRepository _brandRepository,
        ICountryOfOriginRepository _countryOfOriginRepository,
        ICatagoryRepository _catagoryRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<RecoverProductCommand, ResultOf<Product>>
    {
        public async Task<ResultOf<Product>> Handle(RecoverProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var audit = await _productRepository.GetAuditByIdAsync(request.AuditId);
                if (audit == null)
                {
                    return Error.NotFound($"No product audit found with AuditId: {request.AuditId}");
                }

                if (audit.IsRecovered)
                {
                    return Error.Conflict($"The product audit with AuditId: {request.AuditId} has already been recovered.");
                }

                var product = await _productRepository.GetByIdAsync(audit.EntityId);


                if (product is null)
                    return Error.Conflict("No Product with the same code");




                var errors = await ValidateProductData(product);

                if (errors.IsFailure)
                    return errors!.Errors;


                await _unitOfWork.StartTransactionAsync();

                product!.RecoverFromSnabShot(audit);
                await _productRepository.UpdateAsync(product);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();


                return product.AsDone();


            }
            catch (Exception ex)
            {
                return Error.Unexpected("An unexpected error occurred while deleting the product.\n", ex.Message);
            }

        }

        private async Task<ResultOf<Done>> ValidateProductData(Product product)
        {
            if (!await _brandRepository.ExistsAsync(product.BrandId))
                return Error.Validation("The specified brand does not exist or deleted.");
            if (!await _countryOfOriginRepository.ExistsAsync(product.BrandId))
                return Error.Validation("The specified brand does not exist or deleted.");
            if (!await _productGroupRepository.ExistsAsync(product.BrandId))
                return Error.Validation("The specified brand does not exist or deleted.");
            if (!await _catagoryRepository.ExistsAsync(product.BrandId))
                return Error.Validation("The specified brand does not exist or deleted.");

            return Done.done.AsDone();
        }



    }
}
