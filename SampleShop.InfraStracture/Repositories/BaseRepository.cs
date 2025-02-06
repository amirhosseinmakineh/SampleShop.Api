using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.Repositories
{
    public class BaseRepository<TKey, TEntity> : IBaseRepository<TKey, TEntity>, IDisposable where TKey : struct where TEntity : BaseEntity<TKey>
    {
        private readonly SampleShopDbContext context;

        public BaseRepository(SampleShopDbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void AddRange(List<TEntity> entityies)
        {
            context.AddRange(entityies);
        }

        public void Delete(TKey key)
        {
            var entity = GetById(key);
            entity.IsDelete = true;

        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public TEntity GetById(TKey key)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(x => x.Id.Equals(key));
            return entity;
        }

        public int SaveChanges()
        {
            return context.SaveChanges();

        }

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }
    }
}
