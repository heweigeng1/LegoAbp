﻿using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.AspNetCore.TestBase;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Tests.TestDatas;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shouldly;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;

namespace LegoAbp.Web.Tests
{
    public abstract class LegoAbpWebTestBase : AbpAspNetCoreIntegratedTestBase<Startup>
    {
        protected static readonly Lazy<string> ContentRootFolder;

        static LegoAbpWebTestBase()
        {
            ContentRootFolder = new Lazy<string>(WebContentDirectoryFinder.CalculateContentRootFolder, true);
        }

        protected LegoAbpWebTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base
                .CreateWebHostBuilder()
                .UseContentRoot(ContentRootFolder.Value);
        }

        #region Get response

        protected async Task<T> GetResponseAsObjectAsync<T>(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var strResponse = await GetResponseAsStringAsync(url, expectedStatusCode);
            return JsonConvert.DeserializeObject<T>(strResponse, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        protected async Task<string> GetResponseAsStringAsync(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await GetResponseAsync(url, expectedStatusCode);
            return await response.Content.ReadAsStringAsync();
        }

        protected async Task<HttpResponseMessage> GetResponseAsync(string url,
            HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var response = await Client.GetAsync(url);
            response.StatusCode.ShouldBe(expectedStatusCode);
            return response;
        }

        #endregion

        #region UsingDbContext

        protected void UsingDbContext(Action<LegoAbpDbContext> action)
        {
            using (var context = IocManager.Resolve<LegoAbpDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected T UsingDbContext<T>(Func<LegoAbpDbContext, T> func)
        {
            T result;

            using (var context = IocManager.Resolve<LegoAbpDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected async Task UsingDbContextAsync(Func<LegoAbpDbContext, Task> action)
        {
            using (var context = IocManager.Resolve<LegoAbpDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected async Task<T> UsingDbContextAsync<T>(Func<LegoAbpDbContext, Task<T>> func)
        {
            T result;

            using (var context = IocManager.Resolve<LegoAbpDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }

        #endregion

        #region ParseHtml

        protected IHtmlDocument ParseHtml(string htmlString)
        {
            return new HtmlParser().ParseDocument(htmlString);
        }

        #endregion
    }
}