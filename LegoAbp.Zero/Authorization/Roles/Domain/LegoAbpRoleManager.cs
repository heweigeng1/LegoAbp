﻿using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace LegoAbp.Zero.Authorization.Roles.Domain
{
    public class LegoAbpRoleManager : AbpRoleManager<Role, User>, IDomainService, ITransientDependency
    {
        public LegoAbpRoleManager(AbpRoleStore<Role, User> store, IEnumerable<IRoleValidator<Role>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<AbpRoleManager<Role, User>> logger, IPermissionManager permissionManager, ICacheManager cacheManager, IUnitOfWorkManager unitOfWorkManager, IRoleManagementConfig roleManagementConfig, IRepository<OrganizationUnit, long> organizationUnitRepository, IRepository<OrganizationUnitRole, long> organizationUnitRoleRepository) : base(store, roleValidators, keyNormalizer, errors, logger, permissionManager, cacheManager, unitOfWorkManager, roleManagementConfig, organizationUnitRepository, organizationUnitRoleRepository)
        {
        }
    }
}
