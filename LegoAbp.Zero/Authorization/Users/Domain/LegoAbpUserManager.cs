using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using LegoAbp.Zero.Authorization.Roles.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class LegoAbpUserManager : AbpUserManager<Role,User>, IDomainService, ITransientDependency
    {
        private readonly IRepository<UserRole, long> _userRoleRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IRepository<Role> _roleRepository;

        public LegoAbpUserManager(LegoAbpRoleManager roleManager,
            UserStore userStore,
            IRepository<UserRole, long> userRoleRepository,
             IRepository<Role> roleRepository,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators, 
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services, ILogger<LegoAbpUserManager> logger,
            IPermissionManager permissionManager, IUnitOfWorkManager unitOfWorkManager, 
            ICacheManager cacheManager, IRepository<OrganizationUnit, long> organizationUnitRepository, 
            IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository,
            IOrganizationUnitSettings organizationUnitSettings, 
            ISettingManager settingManager) : base(roleManager, userStore, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger, permissionManager, unitOfWorkManager, cacheManager, organizationUnitRepository, userOrganizationUnitRepository, organizationUnitSettings, settingManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }
        public List<string> GetUserRoles(long userId, int? tenantId)
        {
            _unitOfWorkManager.Current.SetTenantId(tenantId);
            var urs = _userRoleRepository.GetAll().Where(c => c.TenantId == tenantId && c.UserId == userId);
            return _roleRepository.GetAll().Where(c => urs.Any(ur => ur.RoleId == c.Id)).Select(c => c.NormalizedName).ToList();
        }
    }
}
