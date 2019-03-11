using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.ModelConfig;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Tenants.ModelConfig
{
    public class TenantMap : EntityConfigurationBase<Tenant, int>
    {
        public const int defaultkey = 1;
        public const string defaultCode = "default";
        public const string defaultTenantName = "default";
        public const string tenantUserPhoneNumber = "13333333333";
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasData(new Tenant { Id = defaultkey, TenantName = defaultTenantName, IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, TenantCode = defaultCode });
            builder.HasData(new TenantUser { Id = defaultkey, CreationTime = DateTime.Now, NickName = UsertMap.defaultName, PhoneNumber = tenantUserPhoneNumber, TenantId = defaultkey, UserId = UsertMap.defaultKey, });
        }
    }
}
