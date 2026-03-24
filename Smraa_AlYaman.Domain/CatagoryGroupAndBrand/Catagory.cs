namespace Smraa_AlYaman.Domain.CatagoryGroupAndBrand
{
    public class Catagory
    {


        public int Id { get; private set; }
        public string Name { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }

        private Catagory() { }
        public Catagory(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }


    }
}
