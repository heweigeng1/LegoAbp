using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Configuration;
using LegoAbp.Core.Web;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace LegoAbp.Web.Startup
{
    [DependsOn(
        typeof(LegoAbpEntityFrameworkCoreModule),
        typeof(AbpAspNetCoreModule),
        typeof(LegoAbpCoreWebModule)
        )]
    public class LegoAbpWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LegoAbpWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(LegoAbpConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<LegoAbpNavigationProvider>();

            //Configuration.Modules.AbpAspNetCore()
            //    .CreateControllersForAppServices(
            //        typeof(LegoAbpApplicationModule).GetAssembly()
            //    );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpWebModule).GetAssembly());
        }
    }
}