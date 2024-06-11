using BlogMaster_Infraestructure.Persistence;
using BlogMaster_Infraestructure.Repositories.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace BlogMaster_Infraestructure.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly IDatabase _database;
        public CacheRepository()
        {
            _database = CacheAccessConfig.Connection.GetDatabase();
        }

        public T Get<T>(string key)
        {
            var data = _database.StringGet(key);
            if (data.IsNullOrEmpty)
            {
                return default(T);
            }

            var dataSerialized = JsonConvert.DeserializeObject<T>(data);
            return dataSerialized;
        }

        public List<T> GetList<T>(string key)
        {
            try
            {
                var data = _database.StringGet(key);
                if (data.IsNullOrEmpty)
                {
                    return new List<T>();
                }

                var dataSerialized = JsonConvert.DeserializeObject<List<T>>(data);
                return dataSerialized;
            }
            catch
            {
                return new List<T>();
            }
        }

        public void SetList<T>(string key, List<T> value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);
            _database.StringSet(key, valueSerialize);
        }

        public void Set<T>(string key, T value)
        {
            var valueSerialize = JsonConvert.SerializeObject(value);
            _database.StringSet(key, valueSerialize);
        }
    }
}
