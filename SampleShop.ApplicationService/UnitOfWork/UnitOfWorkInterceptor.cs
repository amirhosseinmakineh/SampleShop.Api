using Castle.DynamicProxy;
using SampleShop.Domain.UnitOfWork;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace SampleShop.ApplicationService.UnitOfWork
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UnitOfWorkAttributeManager attribute;

        public UnitOfWorkInterceptor(IUnitOfWork unitOfWork, UnitOfWorkAttributeManager attribute)
        {
            this.unitOfWork = unitOfWork;
            this.attribute = attribute;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                var targetName = invocation.Method.DeclaringType.Name + "/" + invocation.Method.Name;

                if (attribute.HasValue(targetName))
                {
                    unitOfWork.Begin();
                    invocation.Proceed();
                    unitOfWork.Commit();
                }
                else
                {
                    invocation.Proceed();
                }
            }
            catch (Exception ex)
            {
                unitOfWork.RoleBack();
            }
        }
    }
}
