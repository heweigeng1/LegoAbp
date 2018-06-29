using Abp.Modules;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Reflection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace LegoAbp.Zero
{
    [DependsOn(
        typeof(LegoAbpEntityFrameworkCoreModule),
        typeof(LegoAbpCoreModule),
        typeof(AbpTreeModule)
        )]
    public class LegoAbpZeroModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Configuration.Settings.Providers.Add<BodeAbpProductSettingProvider>();
            //Configuration.Authorization.Providers.Add<BodeAbpProductAuthorizationProvider>();
            //DefaultDbContextInitializer.Instance.MapperAssemblies.Add(Assembly.GetExecutingAssembly());
            var ass = Assembly.GetExecutingAssembly();
            EntityTypeMapBuilder.ModuleAssemblys.Add(ass);
            System.Console.WriteLine("aaaa");
            DependencyContext context = DependencyContext.Default;
            var ass1 = new EntityConfigurationAssemblyFinder(new AppDomainAllAssemblyFinder());
            var b = ass1.FindAll();
            var a1 = 0;
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 初始化后执行
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
