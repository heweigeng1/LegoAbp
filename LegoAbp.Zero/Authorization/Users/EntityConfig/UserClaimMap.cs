﻿using Abp.Authorization.Users;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserClaimMap : EntityConfigurationBase<UserClaim, long>
    {
        public override void Configure(EntityTypeBuilder<UserClaim> builder)
        {

        }
    }
}