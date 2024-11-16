using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class ProductDetailRepository : BaseRepository<long, ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(SampleShopDbContext context) : base(context)
        {
        }
    }
}
