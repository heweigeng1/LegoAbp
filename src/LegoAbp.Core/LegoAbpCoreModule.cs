using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Localization;

namespace LegoAbp
{
    public class LegoAbpCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            LegoAbpLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreModule).GetAssembly());
        }
    }
}