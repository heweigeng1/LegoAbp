using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users.ModelCongier
{
    public class UserMap : EntityConfigurationBase<User,Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {

        }
    }
}
