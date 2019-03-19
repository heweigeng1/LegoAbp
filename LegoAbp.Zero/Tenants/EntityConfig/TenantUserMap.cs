using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.EntityConfig;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants.EntityConfig
{
    public class TenantUserMap : EntityConfigurationBase<TenantUser>
    {
        public const string tenantUserPhoneNumber = "13333333333";
        public override void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            builder.HasKey(c => new { c.TenantId, c.UserId });
            //添加租户用户
            builder.HasData(new TenantUser { CreationTime = DateTime.Now, NickName = UserMap.defaultName, PhoneNumber = tenantUserPhoneNumber, TenantId = TenantMap.defaultKey, UserId = UserMap.defaultKey, });
        }
    }
}
