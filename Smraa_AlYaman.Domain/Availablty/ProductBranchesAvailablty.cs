namespace Smraa_AlYaman.Domain.Availablty
{
    public class ProductBranchesAvailability
    {
        public int ProductId { get; private set; }
        public int BrancheId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private ProductBranchesAvailability() { }


        public ProductBranchesAvailability(int productId, int brancheId)
        {
            ProductId = productId;
            BrancheId = brancheId;
            CreatedAt = DateTime.Now;
        }


    }
}
