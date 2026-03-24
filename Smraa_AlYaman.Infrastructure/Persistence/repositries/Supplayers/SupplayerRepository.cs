using Microsoft.EntityFrameworkCore;
using Smraa_AlYaman.Application.Common.Interfaces;
using Smraa_AlYaman.Domain.Suppliers;

namespace Smraa_AlYaman.Infrastructure.Persistence.repositries.Supplayers
{
    public class SupplayerRepository : ISupplayerRepository
    {
        private readonly SmraaAlYamanDbContext _context;

        public SupplayerRepository(SmraaAlYamanDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Supplayer supplier)
        {
            await _context.Supplayers.AddAsync(supplier);
        }

        public Task UpdateAsync(Supplayer supplayer)
        {
            _context.Supplayers.Update(supplayer);
            return Task.CompletedTask;
        }

        public async Task<Supplayer> GetByIdAsync(int id)
        {
            return await _context.Supplayers.FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
