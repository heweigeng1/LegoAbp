using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LegoAbp.Zero.Users.ModelCongier
{
    class UserMap : IEntityTypeConfiguration<User>, IEntityRegister
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

        }
    }
}
