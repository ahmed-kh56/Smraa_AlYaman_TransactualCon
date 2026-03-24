using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Barcodes.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IBarcodeRepository
    {

        Task<Barcode?> GetByCodeAsync(string code, bool isDeleted = false);

        Task AddAsync(Barcode barcode);
        Task UpdateAsync(Barcode barcode);
        Task<bool> ExistsAsync(string code);
        Task<IEnumerable<Barcode>> GetBarcodesAsync(int? productId = null);
        Task<IEnumerable<BarcodeAudit>> GetBarcodeAudits(int? productId, string? barcod, int pageSize, int pageNumber);
        Task<BarcodeAudit> GetAuditAsync(Guid auditId);

    }
}
