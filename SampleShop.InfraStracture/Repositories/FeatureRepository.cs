using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class FeatureRepository : BaseRepository<long, Featur>, IFeatureRepository
    {
        public FeatureRepository(SampleShopDbContext context) : base(context)
        {
        }
    }
}
