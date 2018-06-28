using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;
using System.Reflection;

namespace LegoAbp.EntityFrameworkCore
{
    [DependsOn(
        typeof(LegoAbpCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class LegoAbpEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            System.Console.WriteLine(EntityTypeMapBuilder.ModuleAssemblys.Count);
            var ass = Assembly.GetExecutingAssembly();
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpEntityFrameworkCoreModule).GetAssembly());
        }
    }
}