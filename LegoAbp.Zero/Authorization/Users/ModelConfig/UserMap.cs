using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Users.ModelConfig
{
    public class UsertMap : EntityConfigurationBase<User, Guid>
    {
        public const long defaultKey = 1;
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = defaultKey, UserName = "admin", IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, Password = "123456" });
        }
    }
}
