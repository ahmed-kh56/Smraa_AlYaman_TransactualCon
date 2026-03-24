using Smraa_AlYaman.Domain.Products;

namespace Smraa_AlYaman.Domain.CatagoryGroupAndBrand
{
    public class Brand
    {


        public int Id { get; private set; }
        public string Name { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }


        public Brand(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }
        private Brand() { }


    }
}
