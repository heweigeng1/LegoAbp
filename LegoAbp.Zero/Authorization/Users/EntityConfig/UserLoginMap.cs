using Abp.Authorization.Users;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserLoginMap : EntityConfigurationBase<UserLogin, long>
    {
        public override void Configure(EntityTypeBuilder<UserLogin> builder)
        {

        }
    }
}
