using Abp.Modules;
using LegoAbp.Zero;
using System.Reflection;

namespace LegoAbp.Core.Web
{
    [DependsOn(typeof(LegoAbpCoreModule),
        typeof(LegoAbpZeroModule))]
    public class LegoAbpCoreWebModule : AbpModule
    {

        public override void PreInitialize()
        {

        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 初始化后执行
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
    }
}
