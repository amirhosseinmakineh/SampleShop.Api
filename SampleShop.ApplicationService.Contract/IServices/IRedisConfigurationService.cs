namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IRedisConfigurationService<TDto> where TDto :class
    {
        TDto GetData<TDto>(string key);
        bool SetData<TDto>(string key, TDto value, DateTimeOffset expirationTime);
        object RemoveData(string key);
    }
}
