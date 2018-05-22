using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Web.Core;
using LegoAbp.Web.Core.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoAbp.Host
{
    [DependsOn(typeof(LegoAbpWebCoreModule))]
    public class LegoAbpHostModule:AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LegoAbpHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpHostModule).GetAssembly());
        }
    }
}
