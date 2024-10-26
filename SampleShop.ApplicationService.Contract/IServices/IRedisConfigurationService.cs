namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IRedisConfigurationService<T> where T :class
    {
        T GetData(string key);
        bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
        object RemoveData(string key);
    }
}
