using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace BlogMaster_Infraestructure.Persistence
{
    public class CacheAccessConfig
    {
        private readonly IConfiguration _configuration;
        private readonly string _redisConnection;
        private Lazy<ConnectionMultiplexer> lazyConnection;
        public CacheAccessConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _redisConnection = _configuration["ConnectionStrings:Redis"];
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(_redisConnection);
            });
        }

        public ConnectionMultiplexer Connection => lazyConnection.Value;
    }
}
