using Newtonsoft.Json;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.InfraStracture.Context;
using StackExchange.Redis;
namespace SampleShop.ApplicationService.Services
{
    public class RedisConfigurationService<T> : IRedisConfigurationService<T> where T : class
    {
        private IDatabase database;
        public RedisConfigurationService()
        {
            ConfigRedis();
        }
        private void ConfigRedis()
        {
            var config = new ConfigurationOptions()
            {
                EndPoints = { "http://localhost:5086/" },
                SocketManager = SocketManager.Shared,
                ConfigurationChannel = ""
            };
            var redis = ConnectionMultiplexer.Connect(config);
            database = redis.GetDatabase();
            var keys = redis.GetServer("http://localhost", 5086).Keys();

        }
        public T GetData(string key)
        {
            var value = database.StringGet(key);
            if (!string.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);
            return default;
            
        }

        public object RemoveData(string key)
        {
            bool _isKeyExist = database.KeyExists(key);
            if (_isKeyExist == true)
            {
                return database.KeyDelete(key);
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = database.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
