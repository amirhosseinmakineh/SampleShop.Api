using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        public ProductRepository(SampleShopDbContext context) : base(context)
        {
        }
    }
}
