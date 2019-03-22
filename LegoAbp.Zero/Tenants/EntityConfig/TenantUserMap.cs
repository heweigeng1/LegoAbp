using LegoAbp.Entites;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.EntityConfig;
using LegoAbp.Zero.Tenants.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants.EntityConfig
{
    public class TenantUserMap : EntityConfigurationBase<TenantUser, long>
    {
        public const long defaultKey = 1;
        public const string tenantUserPhoneNumber = "13333333333";
        public override void Configure(EntityTypeBuilder<TenantUser> builder)
        {
            //添加租户用户
            builder.HasData(new TenantUser { Id = defaultKey, CreationTime = MapStaticValue.DefaultTime, NickName = UserMap.defaultName, PhoneNumber = tenantUserPhoneNumber, TenantId = TenantMap.defaultKey, UserId = UserMap.defaultKey });
        }
    }
}
