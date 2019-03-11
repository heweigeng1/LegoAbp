using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Users.ModelConfig
{
    public class UsertMap : EntityConfigurationBase<User, long>
    {
        public const long defaultKey = 1;
        public const string defaultName = "admin";
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = defaultKey, UserName = defaultName, IsDeleted = false, IsActive = true, CreationTime = DateTime.Now, Password = "123456" });
        }
    }
}
