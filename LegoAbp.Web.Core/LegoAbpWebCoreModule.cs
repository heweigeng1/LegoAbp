using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.AspNetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using LegoAbp.Zero;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using LegoAbp.Web.Core.Configuration;
using LegoAbp.Core;

namespace LegoAbp.Web.Core
{
    [DependsOn(typeof(LegoAbpZeroModule),
        typeof(LegoAbpCoreModule)
        )]
    public class LegoAbpWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LegoAbpWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(LegoAbpZeroModule).GetAssembly()
                 );

        }



        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpWebCoreModule).GetAssembly());
        }
    }
}
