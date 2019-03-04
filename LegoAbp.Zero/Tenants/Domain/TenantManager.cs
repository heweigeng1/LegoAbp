using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Localization;
using Abp.UI;
using LegoAbp.Zero;
using LegoAbp.Zero.Authorization.Users.Domain;
using System;
using System.Globalization;
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
