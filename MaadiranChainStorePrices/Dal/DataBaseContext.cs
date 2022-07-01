using MaadiranChainStorePrices.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaadiranChainStorePrices.Dal
{
    public class DataBaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DataBaseContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("TbChainStorePriceUser");
            modelBuilder.Entity<Brand>().ToTable("TbChainStorePriceBrand");

            modelBuilder.Entity<User>().HasData(new User { FullName = "رحیم لطفی", Password = BCrypt.Net.BCrypt.HashPassword("799368cr"), PersonelCode = "12002", UserName = "ChainStoreAdmin" });
        }
    }
}