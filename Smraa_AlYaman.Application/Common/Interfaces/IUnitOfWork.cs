namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        bool IsInTransaction { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task StartTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
