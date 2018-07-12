using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Repository;
using System.Reflection;

namespace LegoAbp.Zero
{
    [DependsOn(
        typeof(LegoAbpEntityFrameworkCoreModule),
        typeof(LegoAbpCoreModule),
        typeof(AbpTreeModule),
        typeof(AbpAutoMapperModule)
        )]
    public class LegoAbpZeroModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(LegoAbpZeroModule).Assembly, moduleName: "app", useConventionalHttpVerbs: true);
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(assembly);
            //注册通用IRepository
            IocManager.Resolve<ILegoAbpModuleRepositoryRegistrar>().ModuleRepositoryRegistrar(assembly);
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
