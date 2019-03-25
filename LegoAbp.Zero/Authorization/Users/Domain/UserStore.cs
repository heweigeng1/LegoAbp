using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Linq;
using Abp.Organizations;
using LegoAbp.Zero.Authorization.Roles.Domain;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class UserStore : AbpUserStore<Role, User>, ITransientDependency
    {
        public UserStore(IUnitOfWorkManager unitOfWorkManager, IRepository<User, long> userRepository, IRepository<Role> roleRepository, IAsyncQueryableExecuter asyncQueryableExecuter, IRepository<UserRole, long> userRoleRepository, IRepository<UserLogin, long> userLoginRepository, IRepository<UserClaim, long> userClaimRepository, IRepository<UserPermissionSetting, long> userPermissionSettingRepository, IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository) : base(unitOfWorkManager, userRepository, roleRepository, asyncQueryableExecuter, userRoleRepository, userLoginRepository, userClaimRepository, userPermissionSettingRepository, userOrganizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }
}
