using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization.Roles;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Castle.Core.Logging;
using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Identity;

namespace LegoAbp.Zero.Authorization.Roles.Domain
{
    public class RoleStore : AbpRoleStore<Role, User>, ITransientDependency
    {
        public RoleStore(IUnitOfWorkManager unitOfWorkManager, IRepository<Role> roleRepository, IRepository<RolePermissionSetting, long> rolePermissionSettingRepository) : base(unitOfWorkManager, roleRepository, rolePermissionSettingRepository)
        {
        }
    }
}
