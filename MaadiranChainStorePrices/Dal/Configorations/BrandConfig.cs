using MaadiranChainStorePrices.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaadiranChainStorePrices.Dal.Configorations
{
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //builder.Property(a => a.CreateDate).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(a => a.BrandName).IsRequired(true);
            builder.Property(a => a.LogoName).IsRequired(true);
            builder.Property(a => a.KatalogName).IsRequired(true);
            builder.Property(a => a.Id).IsRequired(true);

            builder.HasIndex(a => a.BrandName).IsUnique(true);
            builder.HasIndex(a => a.LogoName).IsUnique(true);
            builder.HasIndex(a => a.KatalogName).IsUnique(true);
        }
    }
}
