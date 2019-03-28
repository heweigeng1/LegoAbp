using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LegoAbp.Core.Web.Configuration;
using LegoAbp.Core.Web.JwtBearer;
using LegoAbp.Zero;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace LegoAbp.Core.Web
{
    [DependsOn(typeof(LegoAbpCoreModule),
        typeof(AbpAspNetCoreModule),
        typeof(LegoAbpZeroModule))]
    public class LegoAbpCoreWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;
        public LegoAbpCoreWebModule(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(LegoAbpCoreWebModule).GetAssembly()
                 );
            ConfigureTokenAuth();
        }

        /// <summary>
        /// 初始化执行
        /// </summary>
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LegoAbpCoreWebModule).GetAssembly());
        }

        /// <summary>
        /// 初始化后执行
        /// </summary>
        public override void PostInitialize()
        {
            base.PostInitialize();
        }
        private void ConfigureTokenAuth()
        {

            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(30);
        }
    }
}
