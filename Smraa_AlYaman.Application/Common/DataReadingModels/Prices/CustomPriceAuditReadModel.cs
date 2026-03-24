namespace Smraa_AlYaman.Application.Common.DataReadingModels.Prices
{
    public class CustomPriceAuditReadModel
    {
        public Guid AuditId { get; set; }
        public int BranchId { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public decimal? LowestPriceForSale { get; set; }
        public Guid? DependencyAuditId { get; set; }
        public string? EntityType { get; set; }
        public string ActionType { get; set; }
        public Guid? UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime ChangedAt { get; set; }
        public bool IsRecovered { get; set; }
    }

}
