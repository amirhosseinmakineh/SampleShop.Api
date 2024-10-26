using Microsoft.EntityFrameworkCore;

namespace SampleShop.InfraStracture.Context
{
    public class SampleShopDbContext:DbContext
    {
        public SampleShopDbContext(DbContextOptions<SampleShopDbContext> options):base(options)
        {
        }

    }
}
