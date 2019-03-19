using Abp.Authorization.Users;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using LegoAbp.Zero.Authorization.Roles.Domain;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class UserStore : AbpUserStore<Role, User>
    {
        public UserStore(IUnitOfWorkManager unitOfWorkManager,
            IRepository<User, long> userRepository,
            IRepository<Role> roleRepository,
            IAsyncQueryableExecuter asyncQueryableExecuter,
            IRepository<Abp.Authorization.Users.UserRole, long> userRoleRepository,
            IRepository<Abp.Authorization.Users.UserLogin, long> userLoginRepository,
            IRepository<Abp.Authorization.Users.UserClaim, long> userClaimRepository,
            IRepository<UserPermissionSetting, long> userPermissionSettingRepository) : base(unitOfWorkManager, userRepository, roleRepository, asyncQueryableExecuter, userRoleRepository, userLoginRepository, userClaimRepository, userPermissionSettingRepository)
        {
        }
    }
}
