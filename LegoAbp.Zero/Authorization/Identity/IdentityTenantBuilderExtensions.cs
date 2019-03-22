using LegoAbp.Zero.Tenants.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace LegoAbp.Zero.Authorization.Identity
{
    public static class IdentityTenantBuilderExtensions
    {
        public static LegoAbpIdentityBuilder AddAbpTenantManager<TTenantManager>(this LegoAbpIdentityBuilder builder)
            where TTenantManager : class
        {
            var type = typeof(TTenantManager);
            var abpManagerType = typeof(LegoAbpTenantManager).MakeGenericType(builder.TenantType, builder.UserType);
            builder.Services.AddScoped(type, provider => provider.GetRequiredService(abpManagerType));
            builder.Services.AddScoped(abpManagerType, type);
            return builder;
        }
    }
}
