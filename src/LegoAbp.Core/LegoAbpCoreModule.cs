using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using LegoAbp.Localization;
using LegoAbp.Reflection;
using System;
using System.Reflection;

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