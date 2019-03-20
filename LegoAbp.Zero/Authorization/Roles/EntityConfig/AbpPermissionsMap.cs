using Abp.Authorization;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Roles.EntityConfig
{
    public class AbpPermissionsMap : EntityConfigurationBase<PermissionSetting, long>
    {
        public override void Configure(EntityTypeBuilder<PermissionSetting> builder)
        {

        }
    }
}
