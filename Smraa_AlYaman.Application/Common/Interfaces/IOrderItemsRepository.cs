namespace Smraa_AlYaman.Application.Common.Interfaces
{
    public interface IOrderItemsRepository
    {
        Task<bool> ExistsAsync(string barcode);
        Task<bool> ExistsAsync(int ProductId);
    }
}
