using Abp.AspNetCore.Configuration;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System.Reflection;

namespace WxOpenApi
{
    [DependsOn(
        typeof(AbpAutoMapperModule))]
    public class WxOpenApiModule : AbpModule
    {
        /// <summary>
        /// 预初始化，通常是用来配置框架以及其它模块
        /// </summary>
        public override void PreInitialize()
        {
            //Configuration.Authorization.Providers.Add<ShundaoAuthorizationProvider>();
            //Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(typeof(WxOpenApiModule).Assembly, moduleName:"app", useConventionalHttpVerbs: true);
            base.PreInitialize();
        }

        /// <summary>
        /// 初始化，一般用来依赖注入的注册
        /// </summary>
        public override void Initialize()
        {
            //把当前程序集的特定类或接口注册到依赖注入容器中
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            var thisAssembly = typeof(WxOpenApiModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
        }

        /// <summary>
        /// 提交初始化，一般用来解析依赖关系
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }

        /// <summary>
        /// 应用关闭时调用
        /// </summary>
        public override void Shutdown()
        {
            base.Shutdown();
        }
    }
}
