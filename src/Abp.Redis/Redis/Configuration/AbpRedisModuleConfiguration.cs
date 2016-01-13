using StackExchange.Redis;

namespace Abp.Redis.Configuration
{
    public class AbpRedisModuleConfiguration : IAbpRedisModuleConfiguration
    {
        public string ConnectionNameOrString { get; set; }
    }
}
