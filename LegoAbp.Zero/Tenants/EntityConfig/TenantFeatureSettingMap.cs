using Abp.MultiTenancy;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Tenants.EntityConfig
{
    public class TenantFeatureSettingMap : EntityConfigurationBase<TenantFeatureSetting, long>
    {
        public override void Configure(EntityTypeBuilder<TenantFeatureSetting> builder)
        {

        }
    }
}
