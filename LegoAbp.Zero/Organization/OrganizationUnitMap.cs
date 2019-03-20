using Abp.Organizations;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Organization
{
    public class OrganizationUnitMap : EntityConfigurationBase<OrganizationUnit, long>
    {
        public override void Configure(EntityTypeBuilder<OrganizationUnit> builder)
        {
        }
    }
}
