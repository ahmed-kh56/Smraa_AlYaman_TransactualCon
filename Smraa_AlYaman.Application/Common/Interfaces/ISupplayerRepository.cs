using Smraa_AlYaman.Domain.Suppliers;
using Smraa_AlYaman.Domain.Suppliers.Audits;

namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface ISupplayerRepository
    {
        Task AddAsync(Supplayer supplier);
        Task UpdateAsync(Supplayer supplayer);
        Task<Supplayer> GetByIdAsync(int id);
    }
}
