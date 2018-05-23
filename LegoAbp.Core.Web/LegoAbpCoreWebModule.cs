using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.AspNetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using LegoAbp.Zero;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using LegoAbp.Core.Web.Configuration;
using LegoAbp.Core;
using LegoAbp.Core.Configuration;
using LegoAbp.Core.AbpExp;

namespace LegoAbp.Core.Web
{
    [DependsOn(typeof(LegoAbpZeroModule),
        typeof(LegoAbpCoreModule)
        )]
    public class LegoAbpCoreWebModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LegoAbpCoreWebModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
               LegoAbpConsts.ConnectionStringName
           );
            Configuration.Modules.AbpAspNetCore2()
                 .CreateControllersForAppServices(
                     typeof(LegoAbpZeroModule).GetAssembly()
                 );

        }



        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreWebModule).GetAssembly());
        }
    }
}
