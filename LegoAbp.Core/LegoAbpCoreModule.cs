using Abp.AspNetCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Core.Configuration;

namespace LegoAbp.Core
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class LegoAbpCoreModule:AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
