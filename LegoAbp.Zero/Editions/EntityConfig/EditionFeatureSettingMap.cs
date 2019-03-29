using Abp.Application.Features;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Editions.EntityConfig
{
    public class EditionFeatureSettingMap : EntityConfigurationBase<EditionFeatureSetting, long>
    {
        public override void Configure(EntityTypeBuilder<EditionFeatureSetting> builder)
        {

        }
    }
}
