using Abp.Authorization.Roles;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Roles.EntityConfig
{
    public class RolePermissionSettingMap : EntityConfigurationBase<RolePermissionSetting, long>
    {
        public override void Configure(EntityTypeBuilder<RolePermissionSetting> builder)
        {

        }
    }
}
