namespace Smraa_AlYaman.Application.Common.DataReadingModels.Availablties
{
    public class ProductAvailabltyData
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductEnglishName { get; set; }
        public int? BranchId { get; set; }
        public int NotAvailabeBranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
