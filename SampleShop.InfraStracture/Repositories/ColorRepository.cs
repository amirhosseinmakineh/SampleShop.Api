using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class ColorRepository : BaseRepository<int, Color>, IColorRepository
    {
        public ColorRepository(SampleShopDbContext context) : base(context)
        {
        }
    }
}
