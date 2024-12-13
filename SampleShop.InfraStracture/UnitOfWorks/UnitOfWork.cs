using Microsoft.EntityFrameworkCore.Storage;
using SampleShop.Domain.UnitOfWork;
using SampleShop.InfraStracture.Context;

namespace SampleShop.InfraStracture.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SampleShopDbContext context;
        private IDbContextTransaction transaction;
        public UnitOfWork(SampleShopDbContext context)
        {
            this.context = context;
        }

        public void Begin()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RoleBack()
        {
            transaction.Rollback();
        }
    }
}
