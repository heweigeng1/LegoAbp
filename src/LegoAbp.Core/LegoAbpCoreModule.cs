using Abp.Modules;
using Abp.Reflection;
using Abp.Reflection.Extensions;
using LegoAbp.Localization;
using LegoAbp.Reflection;
using System;
using System.Reflection;

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
            var ass = Assembly.GetEntryAssembly();
            var ass2 = Assembly.GetExecutingAssembly();
            var ass3 = Assembly.GetCallingAssembly();
            var ass4 = GetAdditionalAssemblies();
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreModule).GetAssembly());
            var list = Abp.Dependency.IocManager.Instance.Resolve<AbpAssemblyFinder>().GetAllAssemblies();
            var list2 = new AppDomainAllAssemblyFinder().FindAll();
           
            Console.WriteLine(list.Count);
        }
    }
}