using StackExchange.Redis;

namespace BlogMaster_Infraestructure.Persistence
{
    public class CacheAccessConfig
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            string redisConnection = "localhost:6379";
            return ConnectionMultiplexer.Connect(redisConnection);
        });

        public static ConnectionMultiplexer Connection => lazyConnection.Value;
    }
}
