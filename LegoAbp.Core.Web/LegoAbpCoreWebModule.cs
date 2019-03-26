using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Zero;
using System.Reflection;

namespace LegoAbp.Core.Web
{
    [DependsOn(typeof(LegoAbpCoreModule),
        typeof(LegoAbpZeroModule))]
    public class LegoAbpCoreWebModule : AbpModule
    {

        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(LegoAbpCoreWebModule).GetAssembly()
                 );
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreWebModule).GetAssembly());
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
