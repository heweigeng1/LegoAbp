using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LegoAbp.Zero.Tenants.ModelConfig
{
    public class TenantMap : EntityConfigurationBase<Tenant, int>
    {
        public override void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasData(new Tenant { Id = 1, TenantName = "defult", IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, TenantCode = "123456" });
        }
    }
}
