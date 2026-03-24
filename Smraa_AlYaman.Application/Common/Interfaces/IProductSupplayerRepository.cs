using Smraa_AlYaman.Application.Common.DataReadingModels.Supplayeres;
using Smraa_AlYaman.Domain.ProductSuppliers;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IProductSupplayerRepository
    {
        Task UpdateBulkAsync(IEnumerable<ProductSupplayer> productSupplayeres);
        Task<IEnumerable<ProductSupplayerRead>> GetByPhoneAsync(int? productId = null, string phone = null, string Name = null);
        Task<IEnumerable<ProductSupplayer>> GetAllByProductIdAndSupplayerId(
            int? productId = null,
            int? supplayerId = null,
            bool includeDeleted = false);
        Task AddAsync(ProductSupplayer productSupplayer);
        Task<ProductSupplayer?> GetByIdsAsync(
            int productId,
            int supplayerId,
            bool includeDeleted = false);
    }
}
