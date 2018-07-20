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
        //public ILocalizationManager LocalizationManager { get; set; }
        public ILocalizationManager _localizationManager;
        protected string LocalizationSourceName { get; set; }
        protected IRepository<Tenant, int> _tenantRepository;
        protected IRepository<User, Guid> _userRepository;
        public TenantManager(IRepository<Tenant, int> tenantRepository, IRepository<User, Guid> userRepository, ILocalizationManager localizationManager)
        {
            _tenantRepository = tenantRepository;
            _userRepository = userRepository;
            //LocalizationManager = NullLocalizationManager.Instance;
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
        public virtual  Task<string> Testbb()
        {
            var l = L("MyLocalization");
            return Task.FromResult(L("MyLocalization"));
        }

        protected virtual Task ValidateTenantNameAsync(string tenantName)
        {
            if (!Regex.IsMatch(tenantName, Tenant.TenancyNameRegex))
            {
                throw new UserFriendlyException(L("InvalidTenancyName"));
            }
            return Task.FromResult(0);
        }
        protected virtual string L(string name)
        {
            var sources = _localizationManager.GetAllSources();
            foreach (var item in sources)
            {
                if (item.Name== LocalizationSourceName)
                {
                    var i = 0;
                    var b = _localizationManager.GetSource(LocalizationSourceName);
                    var cc = CultureInfo.CurrentUICulture;
                    var c = b.GetString(name);
                }
            }
            
            return _localizationManager.GetString(LocalizationSourceName, name);
        }
    }
}
