using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;

namespace Smraa_AlYaman.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler(
        IProductRepository _productRepository,
        IUnitOfWork _unitOfWork,
        IOrderItemsRepository _orderItemsRepository)
        : IRequestHandler<DeleteProductCommand, ResultOf<Done>>
    {

        public async Task<ResultOf<Done>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.ProductId);
                if (product is null)
                    return Error.NotFound("Product not found");



                product.MarkAsDeleted();
                await _productRepository.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();
                return Done.done.AsNoContent();

            }
            catch (Exception ex)
            {
                return Error.Unexpected("An unexpected error occurred while deleting the product.\n", ex.Message);
            }



        }
    }
}
