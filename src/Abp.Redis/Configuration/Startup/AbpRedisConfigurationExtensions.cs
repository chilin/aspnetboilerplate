using Abp.Redis.Configuration;

namespace Abp.Configuration.Startup
{
    /// <summary>
    /// Defines extension methods to <see cref="IModuleConfigurations"/> to allow to configure ABP Redis module.
    /// </summary>
    public static class AbpRedisConfigurationExtensions
    {
        /// <summary>
        /// Used to configure ABP Redis module.
        /// </summary>
        public static IAbpRedisModuleConfiguration AbpRedis(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.Abp.Redis", () => configurations.AbpConfiguration.IocManager.Resolve<IAbpRedisModuleConfiguration>()); 
        }
    }
}
