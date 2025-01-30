using System.Reflection;

namespace SampleShop.ApplicationService.UnitOfWork
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute:Attribute
    {
    }
    public class UnitOfWorkAttributeManager
    {
        private readonly HashSet<string> unitOfWorkAttributes;

        public UnitOfWorkAttributeManager(HashSet<string> unitOfWorkAttributes)
        {
            this.unitOfWorkAttributes = unitOfWorkAttributes;
        }

        public void SetValue()
        {
            var targets = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(x => x.GetMethods()
                .Where(x => x.GetCustomAttributes()
                .Any(x => x is UnitOfWorkAttribute)));
            foreach (var target in targets)
            {
                var targetName = "I" + target.DeclaringType.Name + "/" + target.Name;
                unitOfWorkAttributes.Add(targetName);
            }
        }

        public bool HasValue(string targetName) => unitOfWorkAttributes.TryGetValue(targetName, out _);
    }
}
