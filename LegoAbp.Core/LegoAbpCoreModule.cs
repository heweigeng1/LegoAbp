using Abp.Modules;
using Abp.Reflection.Extensions;

namespace LegoAbp.Core
{
    public class LegoAbpCoreModule:AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
