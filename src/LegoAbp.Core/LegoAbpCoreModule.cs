using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Localization;

namespace LegoAbp
{
    public class LegoAbpCoreModule : AbpModule
    {
        private IIocManager _iocManager;
        public LegoAbpCoreModule(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            LegoAbpLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreModule).GetAssembly());
            //_iocManager.IocContainer.Register(Component.For<IAppDomainAllAssemblyFinder, AppDomainAllAssemblyFinder>().ImplementedBy<AppDomainAllAssemblyFinder>().LifestyleSingleton());
        }
    }
}