using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.AspNetCore.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using LegoAbp.Zero;

namespace LegoAbp.Web.Core
{
    [DependsOn(typeof(LegoAbpZeroModule))]
    public class LegoAbpWebCoreModule : AbpModule
    {
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
