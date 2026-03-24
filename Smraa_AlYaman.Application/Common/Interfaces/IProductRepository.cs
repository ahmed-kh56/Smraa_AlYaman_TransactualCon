using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Domain.Products;
using Smraa_AlYaman.Domain.Products.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int Id);
        Task<bool> ExistsAsync(int id);
        Task<IEnumerable<ProductDetailsModel>> GetAllAsync(
            int pageSize = 12,
            int pageNum = 0,
            int? groupeId = null,
            int? brandId = null,
            int? countryOfOrigenId = null,
            int? catagoryId = null,
            ProductState? productState = null,
            ProductReceiptType? receiptType = null,
            ProductTransactionType? transactionType = null);
        Task<ProductDetailsModel?> GetDataModelAsync(int ProductId);
        Task<IEnumerable<ProductAudit>> GetAllHistoriesAsync(
            int? id = null,
            int? brandId = null,
            int? catagoryId = null,
            int? countryOfOriginId = null,
            int? groupId = null,
            int? productState = null,
            int? receiptType = null,
            int? transactionType = null,
            int pageSize = 12,
            int pageNumber = 0);
        Task<ProductAudit> GetAuditByIdAsync(Guid auditId);
    }
}
