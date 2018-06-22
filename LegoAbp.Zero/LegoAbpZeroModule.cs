using Abp.Modules;
using AbpTree;
using LegoAbp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
