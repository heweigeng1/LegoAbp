using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Web.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoAbp.Host
{
    [DependsOn(typeof(LegoAbpWebCoreModule))]
    public class LegoAbpHostModule:AbpModule
    {


        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpHostModule).GetAssembly());
        }
    }
}
