using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Barcodes;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Orders
{
    public class OrderItemsRepository : IOrderItemsRepository
    {
        private readonly SmraaAlYamanDbContext _dbContext;

        public OrderItemsRepository(SmraaAlYamanDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> ExistsAsync(string barcode)
        {
            return await _dbContext.OrderItems.AnyAsync(oi => oi.Barcode == barcode);
        }

        public async Task<bool> ExistsAsync(int productId)
        {
            return await (
                from oi in _dbContext.OrderItems
                join b in _dbContext.Barcodes
                    on oi.Barcode equals b.Code
                where b.ProductId == productId
                select oi
            ).AnyAsync();
        }

    }
}
