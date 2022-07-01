using MaadiranChainStorePrices.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaadiranChainStorePrices.Dal.Configorations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.Property(a => a.CreateDate).HasDefaultValueSql("getdate()").ValueGeneratedOnAdd().IsRequired(true);
            builder.Property(a => a.UserName).IsRequired(true);
            builder.Property(a => a.Password).IsRequired(true);
            builder.Property(a => a.PersonelCode).IsRequired(true);
            builder.Property(a => a.Id).IsRequired(true);

            builder.HasIndex(a => a.UserName).IsUnique(true);
            builder.HasIndex(a => a.Password).IsUnique(true);
        }
    }
}
