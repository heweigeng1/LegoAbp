using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Web.Startup;
namespace LegoAbp.Web.Tests
{
    [DependsOn(
        typeof(LegoAbpWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class LegoAbpWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpWebTestModule).GetAssembly());
        }
    }
}