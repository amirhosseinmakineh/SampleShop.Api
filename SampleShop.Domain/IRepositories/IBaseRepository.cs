using SampleShop.Domain.Models;

namespace SampleShop.Domain.IRepositories
{
    public interface IBaseRepository<TKey,TEntity> where TKey : struct where TEntity : BaseEntity<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(TKey key);
        int SaveChanges();
        void Delete(TKey key);
    }
}
