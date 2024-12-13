namespace SampleShop.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Begin();
        void Commit();
        void RoleBack();
    }
}
