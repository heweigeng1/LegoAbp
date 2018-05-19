using Abp.Modules;
using Abp.Reflection.Extensions;

namespace LegoAbp.Zero
{
    public class LegoAbpZeroModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpZeroModule).GetAssembly());
        }

        public override void PostInitialize()
        {

        }
    }
}
