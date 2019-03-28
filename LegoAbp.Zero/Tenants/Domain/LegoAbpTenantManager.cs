using Abp.Application.Features;
using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.MultiTenancy;
using Abp.UI;
using LegoAbp.Zero.Authorization.Users.Domain;
using LegoAbp.Zero.Editions.Domain;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class LegoAbpTenantManager : AbpTenantManager<Tenant, User>, ITransientDependency
    {
        public ILocalizationManager _localizationManager;

        protected readonly IRepository<Tenant> _tenantRepository;
        protected readonly IRepository<UserRole, long> _userRoleRepository;
        protected readonly IRepository<User, long> _userRepository;

        public LegoAbpTenantManager(IRepository<Tenant> tenantRepository, IRepository<UserRole, long> userRoleRepository, IRepository<User, long> userRepository, IRepository<TenantFeatureSetting, long> tenantFeatureRepository, LegoAbpEditionManager editionManager, IAbpZeroFeatureValueStore featureValueStore) : base(tenantRepository, tenantFeatureRepository, editionManager, featureValueStore)
        {
            _tenantRepository = tenantRepository;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
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

    }
}
