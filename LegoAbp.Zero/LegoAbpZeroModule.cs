using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Dependency;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Localization.Sources;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Repository;
using LegoAbp.Zero;
using LegoAbp.Zero.Authorization.Identity.Localization;
using LegoAbp.Zero.Localization;
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
            //配置Identity本地化文件
            LegoAbpZeroIdentityLocalization.Configure(Configuration.Localization);
            //添加租户的本地化文本
            LegoAbpZeroLocalization.Configure(Configuration.Localization);
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
