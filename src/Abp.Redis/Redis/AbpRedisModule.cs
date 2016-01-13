using Abp.Modules;
using Abp.Redis.Configuration;
using System.Reflection;

namespace Abp.Redis
{
    /// <summary>
    /// This module is used to access Redis easily in Abp
    /// </summary>
    [DependsOn(typeof(AbpKernelModule))]
    public class AbpRedisModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IAbpRedisModuleConfiguration, AbpRedisModuleConfiguration>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
