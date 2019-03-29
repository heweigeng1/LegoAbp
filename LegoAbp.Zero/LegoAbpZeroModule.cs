using Abp.Application.Features;
using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Zero;
using Abp.Zero.Configuration;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Repository;
using LegoAbp.Zero.Authorization;
using LegoAbp.Zero.Authorization.Identity.Localization;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Localization;
using LegoAbp.Zero.Tenants.Domain;
using System.Reflection;

namespace LegoAbp.Zero
{
    [DependsOn(
        typeof(LegoAbpEntityFrameworkCoreModule),
        typeof(LegoAbpCoreModule),
        typeof(AbpTreeModule),
        typeof(AbpZeroCoreModule),
        typeof(AbpAutoMapperModule)
        )]
    public class LegoAbpZeroModule : AbpModule
    {
        public override void PreInitialize()
        {
            //开启多租户
            Configuration.MultiTenancy.IsEnabled = true;
            Configuration.Auditing.IsEnabled = true;
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            IocManager.Register<IAbpZeroFeatureValueStore, AbpFeatureValueStore<Tenant,User>>(Abp.Dependency.DependencyLifeStyle.Transient);
            //配置Identity本地化文件
            LegoAbpZeroIdentityLocalization.Configure(Configuration.Localization);
            //添加租户的本地化文本
            LegoAbpZeroLocalization.Configure(Configuration.Localization);
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(LegoAbpZeroModule).Assembly, moduleName: "app", useConventionalHttpVerbs: true);
            Configuration.Authorization.Providers.Add<LegoAbpZeroAuthorizationProvider>();
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
