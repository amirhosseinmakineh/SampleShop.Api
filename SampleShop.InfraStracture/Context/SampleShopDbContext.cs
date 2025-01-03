using Microsoft.EntityFrameworkCore;
using SampleShop.Domain.Models;

namespace SampleShop.InfraStracture.Context
{
    public class SampleShopDbContext : DbContext
    {
        public SampleShopDbContext(DbContextOptions<SampleShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Featur> Featurs { get; set; }
        public DbSet<Slider> Sliders { get; set; }
    }
}
