using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Smraa_AlYaman.Domain.CatagoryGroupAndBrand
{
    public class CountryOfOriginConfiguration :IEntityTypeConfiguration<CountryOfOrigin>
    {
        public void Configure(EntityTypeBuilder<CountryOfOrigin> builder)
        {
            builder.ToTable("CountriesOfOrigin");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.ZCode)
                   .HasMaxLength(10);
        }
    }

}
