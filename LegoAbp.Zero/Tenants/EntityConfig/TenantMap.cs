using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.EntityConfig;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Tenants.EntityConfig
{
    public class TenantMap : EntityConfigurationBase<Tenant>
    {
        public const int defaultKey = 1;
        public const string defaultCode = "default";
        public const string defaultName = "default";
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasData(new Tenant { Id = defaultKey, Name = defaultName, TenancyName = defaultName, IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, TenantCode = defaultCode });
        }
    }
}
