using Abp.BackgroundJobs;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.BackgroundJobs
{
    public class BackgroundJobInfoMap : EntityConfigurationBase<BackgroundJobInfo, long>
    {
        public override void Configure(EntityTypeBuilder<BackgroundJobInfo> builder)
        {
        }
    }
}
