using LegoAbp.Entites;
using LegoAbp.EntityFrameworkCore;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserMap : EntityConfigurationBase<User, long>
    {

        public const long defaultKey = 1;
        public const string defaultName = "admin";
        public const string defaultPassword = "qwe123";
        public const string defaultPhoneNumber = "13333333333";

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            var admin = new User { Id = defaultKey, UserName = defaultName, Name = defaultName, NormalizedUserName = defaultName.ToUpper(), PhoneNumber = defaultPhoneNumber, IsDeleted = false, IsActive = true, CreationTime = MapStaticValue.DefaultTime };
            admin.Password = new PasswordHasher<User>().HashPassword(admin, defaultPassword);
            builder.HasData(admin);
        }
        public override void RegistTo(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasOne(c => c.CreatorUser).WithMany().HasForeignKey(p => p.CreatorUserId);
                u.HasOne(c => c.DeleterUser).WithMany().HasForeignKey(p => p.DeleterUserId);
                u.HasOne(c => c.LastModifierUser) .WithMany().HasForeignKey(p => p.LastModifierUserId);
            });
            base.RegistTo(modelBuilder);
        }
    }
}
