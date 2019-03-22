using Abp.Application.Editions;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Editions.EntityConfig
{
    public class EditionMap : EntityConfigurationBase<Edition, int>
    {
        public override void Configure(EntityTypeBuilder<Edition> builder)
        {
        }
    }
}
