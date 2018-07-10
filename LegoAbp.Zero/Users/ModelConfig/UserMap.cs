using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Users.ModelConfig
{
    public  class UserMap : EntityConfigurationBase<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = Guid.NewGuid(), UserName = "admin", IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, Password = "123456" });
        }
    }
}
