using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.DataReadingModels.ProductsData;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Products;
using Smraa_AlYaman.Domain.Products.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Productrepositries
{
    internal class ProductRepository : IProductRepository
    {
        private readonly SmraaAlYamanDbContext _context;

        private readonly IDbSettings _dbSettings;

        public ProductRepository(IDbSettings dbSettings, SmraaAlYamanDbContext context)
        {
            _dbSettings = dbSettings;
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }


        public async Task<bool> ExistsAsync(int id)
        {
            var procName = "ProductsData.CheckProductExists";
            var parameters = new { Id = id };
            using var connection = _dbSettings.CreateConnection();

            var result = await connection.QuerySingleAsync<int>(
                procName,
                parameters,
                commandType: CommandType.StoredProcedure);

            return result == 1;
        }
        /*
         * view and proc is in the chat with chat GPT and will be edited later
         */
        // DONE
        public async Task<IEnumerable<ProductDetailsModel>> GetAllAsync(
            int pageSize = 12,
            int pageNum = 0,
            int? groupeId = null,
            int? brandId = null,
            int? countryOfOrigenId = null,
            int? catagoryId = null,
            ProductState? productState = null,
            ProductReceiptType? receiptType = null,
            ProductTransactionType? transactionType = null)
        {
            var command = "[ProductData].sp_GetProducts";
            var parameters = new
            {
                PageSize = pageSize,
                PageNumber = pageNum,
                GroupId = groupeId,
                BrandId = brandId,
                CountryOfOriginId = countryOfOrigenId,
                CategoryId = catagoryId,
                ProductState = productState,
                ReceiptType = receiptType,
                TransactionType = transactionType
            };

            using var connection = _dbSettings.CreateConnection();
            return await connection.QueryAsync<ProductDetailsModel>(command,parameters);

        }
        /*
         * the data reading model need to be updatd and not it only the veiw and proc has to
         * view and proc is in the chat with chat GPT and will be edited later
         */
        // DONE
        public async Task<ProductDetailsModel?> GetDataModelAsync(int productId)
        {
            var sql = "ProductData.sp_GetProductDetailsById";

            using var conn = _dbSettings.CreateConnection();

            var result = await conn.QueryAsync<ProductDetailsModel, ProductPriceData, ProductDetailsModel>(
                sql,
                (product, price) =>
                {
                    product.PriceData = price;
                    return product;
                },
                new { ProductId = productId },
                splitOn: "PricePerSmallistUnit",
                commandType: CommandType.StoredProcedure
            );

            return result.FirstOrDefault();
        }
        /*
         * view and proc is in the chat with chat GPT and will be edited later
         */

        // DONE
        public async Task<IEnumerable<ProductAudit>> GetAllHistoriesAsync(
            int? id = null,
            int? brandId = null,
            int? catagoryId = null,
            int? countryOfOriginId = null,
            int? groupId = null,
            int? productState = null,
            int? receiptType = null,
            int? transactionType = null,
            int pageSize = 12,
            int pageNumber = 0)
        {
            using var connection = _dbSettings.CreateConnection();

            var parameters = new
            {
                Id = id,
                BrandId = brandId,
                CategoryId = catagoryId,
                CountryOfOriginId = countryOfOriginId,
                GroupId = groupId,
                ProductState = productState,
                ReceiptType = receiptType,
                TransactionType = transactionType,
                PageSize = pageSize,
                PageNumber = pageNumber
            };

            return await connection.QueryAsync<ProductAudit>(
                "[ProductData].sp_GetProductAuditHistories",
                parameters,
                commandType: CommandType.StoredProcedure);
        }


        public async Task<ProductAudit> GetAuditByIdAsync(Guid auditId)
        {
            return await _context.ProductAudits.FirstOrDefaultAsync(pa=>pa.AuditId==auditId);
        }

        public async Task<Product> GetByIdAsync(int ProductId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == ProductId);
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await Task.CompletedTask;
        }
    }
}
