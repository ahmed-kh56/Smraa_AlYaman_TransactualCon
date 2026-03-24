using Smraa_AlYaman.Domain.ProductPrices;
using Smraa_AlYaman.Domain.ProductPrices.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IProductPriceRepository
    {
        Task AddAsync(ProductPrice productPrice);
        Task UpdateAsync(ProductPrice productPrice);
        Task<ProductPriceAudit> GetAuditByIdAsync(Guid id);
        Task<IEnumerable<ProductPriceAudit>> GetAllHistoriesAsync(
            int? id = null,
            int pageSize = 12,
            int pageNumber = 0);
        Task UpdateAuditAsync(ProductPriceAudit audit);
        Task<ProductPrice> GetByIdAsync(int entityId);
    }
}
