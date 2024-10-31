using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class CategoryRepository : BaseRepository<long, Category>, ICategoryRepository
    {
        public CategoryRepository(SampleShopDbContext context) : base(context)
        {
        }
    }
}
