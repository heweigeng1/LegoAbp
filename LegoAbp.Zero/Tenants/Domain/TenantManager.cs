
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Localization;
using Abp.UI;
using LegoAbp.Zero.Authorization.Roles.Domain;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class TenantManager : IDomainService
    {
        public ILocalizationManager _localizationManager;
        protected string LocalizationSourceName { get; set; }

        protected IRepository<Tenant, int> _tenantRepository;
        protected IRepository<UserRole, Guid> _userRoleRepository;
        protected IRepository<User, long> _userRepository;
        public TenantManager(IRepository<Tenant, int> tenantRepository, IRepository<User, long> userRepository, ILocalizationManager localizationManager, IRepository<UserRole, Guid> userRoleRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _localizationManager = localizationManager;
            _userRoleRepository = userRoleRepository;
            LocalizationSourceName = LegoAbpZeroConsts.LocalizationSourceName;
        }

        public virtual async Task CreateAsync(Tenant tenant)
        {
            await ValidateTenantNameAsync(tenant.Name);

            if (_tenantRepository.FirstOrDefault(c => c.Name == tenant.Name) != null)
            {
                throw new UserFriendlyException("TenancyNameIsAlreadyTaken");
            }
            await _tenantRepository.InsertAsync(tenant);
        }

        /// <summary>
        /// 移除租户用户的角色
        /// </summary>
        /// <param name="tenantUser"></param>
        /// <returns></returns>
        public virtual async Task RemoveTenantUserRoleAsync(TenantUser tenantUser)
        {
            var data = _userRoleRepository.GetAll().Where(c => c.UserId == tenantUser.UserId && c.TenantId == tenantUser.TenantId).ToList();
            foreach (var item in data)
            {
               await _userRoleRepository.DeleteAsync(item);
            }
        }

        /// <summary>
        /// 修改租户名
        /// </summary>
        /// <param name="newTenantName"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual async Task ChangeTenantNameAsync(string newTenantName, int Id)
        {
            await ValidateTenantNameAsync(newTenantName);
            if (_tenantRepository.GetAll().Any(c => c.Id != Id && c.Name == newTenantName))
            {
                throw new UserFriendlyException("店铺名称已被占用");
            }
            var entity = _tenantRepository.FirstOrDefault(c => c.Id == Id);
            entity.Name = newTenantName;
            await _tenantRepository.UpdateAsync(entity);
        }

        protected virtual Task ValidateTenantNameAsync(string tenantName)
        {
            if (!Regex.IsMatch(tenantName, Tenant.TenancyNameRegex))
            {
                throw new UserFriendlyException(L("InvalidTenancyName"));
            }
            return Task.CompletedTask;
        }

        protected virtual string L(string name)
        {
            return _localizationManager.GetString(LocalizationSourceName, name);
        }
    }
}
