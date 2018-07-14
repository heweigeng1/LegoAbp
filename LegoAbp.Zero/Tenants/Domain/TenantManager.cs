using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Localization;
using Abp.UI;
using LegoAbp.Zero.Users.Domain;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Tenants.Domain
{
    public class TenantManager : IDomainService
    {
        public ILocalizationManager LocalizationManager { get; set; }

        protected IRepository<Tenant, int> _tenantRepository;
        protected IRepository<User, Guid> _userRepository;
        public TenantManager(IRepository<Tenant, int> tenantRepository, IRepository<User, Guid> userRepository)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            LocalizationManager = NullLocalizationManager.Instance;
        }
        public virtual async Task CreateAsync(Tenant tenant)
        {
            await ValidateTenantNameAsync(tenant);

            if (_tenantRepository.FirstOrDefault(c => c.TenantName == tenant.TenantName) != null)
            {
                throw new UserFriendlyException();
            }
            await _tenantRepository.InsertAsync(tenant);
        }

        protected virtual Task ValidateTenantNameAsync(Tenant tenant)
        {
            if (!Regex.IsMatch(tenant.TenantName, Tenant.TenancyNameRegex))
            {
                throw new UserFriendlyException();
            }
            return Task.FromResult(0);
        }
    }
}
