using Abp.Authorization.Users;
using LegoAbp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegoAbp.Zero.Authorization.Users.EntityConfig
{
    public class UserPermissionSettingMap : EntityConfigurationBase<UserPermissionSetting, long>
    {
        public override void Configure(EntityTypeBuilder<UserPermissionSetting> builder)
        {

        }
    }
}
