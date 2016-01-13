using StackExchange.Redis;

namespace Abp.Redis.Configuration
{
    public interface IAbpRedisModuleConfiguration
    {
        string ConnectionNameOrString { get; set; }
    }
}
