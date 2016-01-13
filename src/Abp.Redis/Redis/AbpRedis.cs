using Abp.Dependency;
using Abp.Redis.Configuration;
using StackExchange.Redis;

namespace Abp.Redis
{
    public class AbpRedis : IAbpRedis, ISingletonDependency
    {
        private readonly IAbpRedisModuleConfiguration _configuration;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public IDatabase Database
        {
            get
            {
                return _connectionMultiplexer.GetDatabase();
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public AbpRedis(
            IAbpRedisConnectionProvider redisConnectionProvider, 
            IAbpRedisModuleConfiguration configuration)
        {
            _configuration = configuration;
            var connectionString = redisConnectionProvider.GetConnectionString(_configuration.ConnectionNameOrString);
            _connectionMultiplexer = redisConnectionProvider.GetConnection(connectionString);
        }
    }
}
