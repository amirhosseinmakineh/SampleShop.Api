using Microsoft.EntityFrameworkCore;
using SampleShop.Domain.Models;

namespace SampleShop.InfraStracture.Context
{
    public class SampleShopDbContext:DbContext
    {
        public SampleShopDbContext(DbContextOptions<SampleShopDbContext> options):base(options)
        {
        }

        public DbSet<Category> Categories { get;set; }  
    }
}
