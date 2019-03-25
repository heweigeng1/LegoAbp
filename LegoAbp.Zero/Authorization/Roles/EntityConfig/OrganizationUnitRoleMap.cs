using Abp.Organizations;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Roles.EntityConfig
{
    public class OrganizationUnitRoleMap : EntityConfigurationBase<OrganizationUnitRole, long>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnitRole> builder)
        {
        }
    }
}
