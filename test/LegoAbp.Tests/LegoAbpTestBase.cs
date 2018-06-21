using System;
using System.Threading.Tasks;
using Abp.TestBase;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Tests.TestDatas;

namespace LegoAbp.Tests
{
    public class LegoAbpTestBase : AbpIntegratedTestBase<LegoAbpTestModule>
    {
        public LegoAbpTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<LegoAbpDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<LegoAbpDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<LegoAbpDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<LegoAbpDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<LegoAbpDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<LegoAbpDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<LegoAbpDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<LegoAbpDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
