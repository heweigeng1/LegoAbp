using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserMap : EntityConfigurationBase<User, long>
    {

        public const long defaultKey = 1;
        public const string defaultName = "admin";
        public const string defaultPassword = "qwe123";

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User { Id = defaultKey, UserName = defaultName, Name = defaultName, NormalizedUserName = defaultName.ToUpper(), IsDeleted = false, IsActive = true, CreationTime = DateTime.Now };
            admin.Password = new PasswordHasher<User>().HashPassword(admin, defaultPassword);
            builder.HasData(admin);
        }
    }
}
