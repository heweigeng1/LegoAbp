using Abp.Authorization.Users;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserLoginAttemptMap : EntityConfigurationBase<UserLoginAttempt, long>
    {
        public override void Configure(EntityTypeBuilder<UserLoginAttempt> builder)
        {
        }
    }
}
