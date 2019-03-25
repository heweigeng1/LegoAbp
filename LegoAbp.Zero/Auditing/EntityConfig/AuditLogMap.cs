using Abp.Auditing;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Auditing.EntityConfig
{
    public class AuditLogMap : EntityConfigurationBase<AuditLog, long>
    {
        public override void Configure(EntityTypeBuilder<AuditLog> builder)
        {

        }
    }
}
