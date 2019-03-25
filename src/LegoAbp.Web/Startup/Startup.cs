using System;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.EntityFrameworkCore;
using LegoAbp.EntityFrameworkCore;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Abp.Extensions;
using LegoAbp.Core.Web.Configuration;
using LegoAbp.Zero.Authorization.Identity;
using System.Reflection;

namespace LegoAbp.Web.Startup
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        private readonly IConfigurationRoot _appConfiguration;
        public Startup(IHostingEnvironment env)
        {
            _appConfiguration = env.GetAppConfiguration();
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //Configure DbContext
            services.AddAbpDbContext<LegoAbpDbContext>(options =>
            {
                DbContextOptionsConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
            });
            IdentityRegistrar.Register(services);
            services.AddMvc(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName));
                //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            // Configure CORS for angular2 UI
            services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            _appConfiguration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        ).AllowCredentials()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Lego API", Version = "v1" });
                c.DocInclusionPredicate((docName, description) => true);

                // Define the BearerAuth scheme that's in use
                //c.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
                //{
                //    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                //    Name = "Authorization",
                //    In = "header",
                //    Type = "apiKey"
                //});
            });
            //Configure Abp and Dependency Injection
            return services.AddAbp<LegoAbpWebModule>(options =>
            {
                //Configure Log4Net logging
                options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); //Initializes ABP framework.
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAbpRequestLocalization();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.InjectOnCompleteJavaScript("/swagger/ui/abp.js");
                //c.InjectOnCompleteJavaScript("/swagger/ui/on-complete.js");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lego API V1");
                //c.SwaggerEndpoint(_appConfiguration["App:ServerRootAddress"] + "/swagger/v1/swagger.json", "Lego API V1");
                c.IndexStream = () => Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream("LegoAbp.Web.wwwroot.swagger.ui.index.html");
            });
        }
    }
}
