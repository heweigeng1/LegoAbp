using Abp.Modules;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Reflection;
using LegoAbp.Zero.Users;
using LegoAbp.Zero.Users.ModelCongier;
using Microsoft.Extensions.DependencyModel;
using System;
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
            var assembly = Assembly.GetExecutingAssembly();
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            var bbb = IocManager.Resolve<IEntityConfigurationTypeFinder>().GetEntityRegisters(typeof(LegoAbpDbContext));
            var b = 0;
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
