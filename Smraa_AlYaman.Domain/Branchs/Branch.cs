using Smraa_AlYaman.Domain.Availablty;
using Smraa_AlYaman.Domain.Branchs.Audits;
using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.CustomPrices;

namespace Smraa_AlYaman.Domain.Branchs
{

    public class Branch
    {
        public int Id { get; private set; }
        public string BranchName { get; private set; }
        public string? BranchAddress { get; private set; }
        public string? BranchPhone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<CustomPrice> CustomPrices { get; private set; } = new List<CustomPrice>();
        public ICollection<ProductBranchesAvailability> ProductAvailabilities { get; private set; } = new List<ProductBranchesAvailability>();
        /*
👉👈 مش عارف ايه الداتا اللي ممكن اخزنهاله فهسيبه على كده بصراحة 
*/


        public Branch(string branchName, string? branchPhone = null, string? branchAddress = null)
        {
            BranchName = branchName;
            BranchPhone = branchPhone;
            BranchAddress = branchAddress;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = null;
        }
        public void MarkAsDeleted()
        {
            if(IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
            LastUpdate = DateTime.UtcNow;
        }

        public void RecoverSnapShot(BranchAudit audit)
        {
            BranchName = audit.BranchName;
            BranchAddress = audit.BranchAddress;
            BranchPhone = audit.BranchPhone;
            LastUpdate = DateTime.UtcNow;
        }

        public void Update(string? branchName = null, string? branchPhone = null, string? branchAddress = null)
        {
            BranchAddress = branchAddress ?? BranchAddress;
            BranchName = branchName ?? BranchName;
            BranchPhone = branchPhone ?? BranchPhone;
            LastUpdate = DateTime.UtcNow;
        }

        private Branch() { }


    }
}
