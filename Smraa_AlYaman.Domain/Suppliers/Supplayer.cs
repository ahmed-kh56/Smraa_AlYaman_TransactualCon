using Smraa_AlYaman.Domain.Common;
using Smraa_AlYaman.Domain.ProductSuppliers;
using Smraa_AlYaman.Domain.Suppliers.Audits;

namespace Smraa_AlYaman.Domain.Suppliers
{
    public class Supplayer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ContactPhone { get; private set; }

        public SupplayerScope Scope { get; private set; } = SupplayerScope.Local;
        public bool IsDeleted { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        public ICollection<ProductSupplayer> ProductSuppliers { get; private set; }= new List<ProductSupplayer>();
        private Supplayer() { }

        public Supplayer(string name, string contactPhone, SupplayerScope scope)
        {
            Name = name;
            ContactPhone = contactPhone;
            Scope = scope;
            CreatedAt = DateTime.Now;
        }

        public void Update(string? name = null, string? phone = null, SupplayerScope? scope = null)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
            if (!string.IsNullOrWhiteSpace(phone))
                ContactPhone = phone;
            if(scope.HasValue)
                Scope = scope.Value;

            LastUpdate = DateTime.Now;
        }
        public void RecoverFormSnapshot(SupplayerAudit snapshot)
        {
            Name = snapshot.Name;
            ContactPhone = snapshot.ContactPhone;
            Scope = Enum.Parse<SupplayerScope>(snapshot.Scope);
            IsDeleted = snapshot.IsDeleted;
            CreatedAt = DateTime.UtcNow;
            LastUpdate = DateTime.UtcNow;
            snapshot.MarkAsRecovered();
        }
        public void MarkAsDeleted()
        {
            if (IsDeleted) throw DomainException.AlreadyDeletedEntity;
            IsDeleted = true;
            LastUpdate = DateTime.Now;
        }
    }

}
