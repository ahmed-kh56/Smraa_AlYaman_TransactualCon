using Dapper;
using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Barcodes;
using Smraa_AlYaman.Domain.Barcodes.Audits;
using Smraa_AlYaman.Infrastructure.Persistence.DbSettings;
using System.Data;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Barcdes
{
    internal class BarcodeRepository : IBarcodeRepository
    {
        private readonly IDbSettings _dbSettings;
        private readonly SmraaAlYamanDbContext _dbContext;
        public BarcodeRepository(IDbSettings dbSettings, SmraaAlYamanDbContext dbContext)
        {
            _dbSettings = dbSettings;
            _dbContext = dbContext;
        }


        public async Task AddAsync(Barcode barcode)
        {
            await _dbContext.AddAsync(barcode);
        }





        public async Task<Barcode?> GetByCodeAsync(string code, bool isDeleted = false)
        {
            return await _dbContext.Barcodes.FirstOrDefaultAsync(b => b.Code == code && b.IsDeleted == isDeleted);
        }

        public Task UpdateAsync(Barcode barcode)
        {
            _dbContext.Barcodes.Update(barcode);
            return Task.CompletedTask;
        }
        public async Task<bool> ExistsAsync(string code)
        {
            return await _dbContext.Barcodes.AnyAsync(b => b.Code == code);
        }

        /*
         need a view and proc 
        */
        //DONE
        public async Task<IEnumerable<Barcode>> GetBarcodesAsync(int? productId = null)
        {
            var command = "BarcodeData.sp_GetBarcodesData";
            var param = new { ProductId = productId };

            using var conn = _dbSettings.CreateConnection();

            return await conn.QueryAsync<Barcode>(
                command,
                param,
                commandType: CommandType.StoredProcedure);
        }
        /*
         need a view and proc 
        */
        //DONE
        public async Task<IEnumerable<BarcodeAudit>> GetBarcodeAudits(
            int? productId,
            string? barcode,
            int pageSize,
            int pageNumber)
        {
            var command = "BarcodeData.sp_GetBarcodeAudits";
            var param = new {
                ProductId = productId,
                Barcode = barcode,
                PageSize = pageSize,
                PageNumber = pageNumber
            };
            using var conn = _dbSettings.CreateConnection();
            return await conn.QueryAsync<BarcodeAudit>(command, param);
        }

        public async Task<BarcodeAudit> GetAuditAsync(Guid auditId)
        {
            return await _dbContext.BarcodeAudits.FirstOrDefaultAsync(a => a.AuditId == auditId);
        }


    }
}
