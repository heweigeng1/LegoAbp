using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Localization;
using Abp.UI;
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
        protected IRepository<User, Guid> _userRepository;
        public TenantManager(IRepository<Tenant, int> tenantRepository, IRepository<User, Guid> userRepository, ILocalizationManager localizationManager)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            _localizationManager = localizationManager;
            LocalizationSourceName = LegoAbpZeroConsts.LocalizationSourceName;
        }
        public virtual async Task CreateAsync(Tenant tenant)
        {
            await ValidateTenantNameAsync(tenant.TenantName);

            if (_tenantRepository.FirstOrDefault(c => c.TenantName == tenant.TenantName) != null)
            {
                throw new UserFriendlyException("TenancyNameIsAlreadyTaken");
            }
            await _tenantRepository.InsertAsync(tenant);
        }
        public virtual async Task ChangeTenantNameAsync(string newTenantName, int Id)
        {

            await ValidateTenantNameAsync(newTenantName);
            if (_tenantRepository.GetAll().Any(c => c.Id != Id && c.TenantName == newTenantName))
            {
                throw new UserFriendlyException("店铺名称已被占用");
            }
            var entity = _tenantRepository.FirstOrDefault(c => c.Id == Id);
            entity.TenantName = newTenantName;
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
