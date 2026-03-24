using Smraa_AlYaman.Application.Common.DataReadingModels.Prices;
using Smraa_AlYaman.Domain.CustomPrices;
using Smraa_AlYaman.Domain.CustomPrices.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface ICustomPriceRepository
    {
        Task AddAsync(CustomPrice price);

        Task<CustomPrice> GetCustomPriceByBarcodeAndBranchAsync(string code, int branchId, bool includeDeleted = false);
        Task DeleteAsync(CustomPrice price);

        Task<IEnumerable<CustomPrice>> GetAllCustomPricesAsync(
            string? code = null,
            int? productId = null,
            int? branchId = null);
        Task<IEnumerable<CustomPrice>> EFCGetAllCustomPricesAsync(
            string? code = null,
            int? productId = null,
            int? branchId = null);

        Task<IEnumerable<CustomPriceAuditReadModel>> GetHistoryAsync(
            string? barcode = null,
            int? branchId = null,
            int pageSize =12,
            int pageNumber = 0);
        Task<CustomPriceAudit> GetAuditAsync(Guid auditId);
        Task UpdateAsync(CustomPrice price);

        Task AddRangeAsync(IEnumerable<CustomPrice> prices);
    }
}
