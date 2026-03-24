namespace Smraa_AlYaman.Domain.CatagoryGroupAndBrand
{
    public class CountryOfOrigin
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string ZCode { get; private set; }


        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }


        private CountryOfOrigin() { }


        public CountryOfOrigin(string name, string zCode)
        {
            Name = name;
            ZCode = zCode;
            CreatedAt = DateTime.UtcNow;
        }


    }
}
