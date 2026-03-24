using MediatR;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Common.Errors;
using Smraa_AlYaman.Common.ResultOf;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductPrices;

namespace Smraa_AlYaman.Application.Prices.Commands.RecoverProductPrice
{
    public class RecoverProductPriceCommandHandler(
        IProductPriceRepository _productPriceRepository,
        IUnitOfWork _unitOfWork) : IRequestHandler<RecoverProductPriceCommand, ResultOf<ProductPrice>>
    {
        public async Task<ResultOf<ProductPrice>> Handle(RecoverProductPriceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var priceAudit = await _productPriceRepository.GetAuditByIdAsync(request.AuditId);
                if (priceAudit is null)
                    return Error.NotFound("NotFound_RecoverProductPriceCommand", $"No price audit found with id {request.AuditId}");

                var price = await _productPriceRepository.GetByIdAsync(priceAudit.EntityId);
                if (price is null)
                    return Error.Forbidden("Forbidden_RecoverProductPriceCommand", $"No price found with id {priceAudit.EntityId}");
                price.RecoverFromSnapshot(priceAudit);
                await _unitOfWork.StartTransactionAsync();

                await _productPriceRepository.UpdateAsync(price);
                await _productPriceRepository.UpdateAuditAsync(priceAudit);
                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();
                return price.AsDone();

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
