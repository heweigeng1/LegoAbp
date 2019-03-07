using Abp.Modules;
using System;
using System.Reflection;

namespace LegoAbp.Auditing
{
    public class LegoAbpAuditingModule:AbpModule
    {

        public override void PreInitialize()
        {
            //Configuration.Settings.Providers.Add<BodeAbpProductSettingProvider>();
            //Configuration.Authorization.Providers.Add<BodeAbpProductAuthorizationProvider>();
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
