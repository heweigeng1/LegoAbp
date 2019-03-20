using Abp.Authorization.Users;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Organization
{
    public class UserOrganizationUnitMap : EntityConfigurationBase<UserOrganizationUnit, long>
    {
        public override void Configure(EntityTypeBuilder<UserOrganizationUnit> builder)
        {
        }
    }
}
