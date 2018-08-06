using Abp;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Linq;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using JetBrains.Annotations;
using LegoAbp.Zero.Authorization.Roles.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace LegoAbp.Zero.Authorization.Users.Domain
{
    public class UserStore : IQueryableUserStore<User>,
        IUserLoginStore<User>,
        IUserRoleStore<User>,
        IUserClaimStore<User>,
        IUserPasswordStore<User>,
        IUserSecurityStampStore<User>,
        IUserEmailStore<User>,
        IUserLockoutStore<User>,
        IUserPhoneNumberStore<User>,
        IUserTwoFactorStore<User>,
        IUserAuthenticationTokenStore<User>,
        IUserAuthenticatorKeyStore<User>,
        //IUserPermissionStore<User>, 这个限定了User类型要重新实现
        ITransientDependency
    {
        /// <summary>
        /// 增删改自动保存
        /// </summary>
        public bool AutoSaveChanges { get; set; } = true;
        public ILogger Logger { get; set; }
        public IdentityErrorDescriber ErrorDescriber { get; set; }
        public IAbpSession AbpSession { get; set; }

        private const string InternalLoginProvider = "[AspNetUserStore]";
        private const string AuthenticatorKeyTokenName = "AuthenticatorKey";

        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<Role, Guid> _roleRepository;
        private readonly IRepository<UserLogin, Guid> _userLoginRepository;
        private readonly IRepository<UserRole, Guid> _userRoleRepository;
        private readonly IAsyncQueryableExecuter _asyncQueryableExecuter;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public UserStore(IRepository<User, Guid> userRepository, IRepository<Role, Guid> roleRepository, IUnitOfWorkManager unitOfWorkManager, IAsyncQueryableExecuter asyncQueryableExecuter)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _asyncQueryableExecuter = asyncQueryableExecuter;
            Logger = NullLogger.Instance;
            ErrorDescriber = new IdentityErrorDescriber();
            AbpSession = NullAbpSession.Instance;
        }

        //protected Task SaveChanges(CancellationToken cancellationToken)
        //{
        //    if (!AutoSaveChanges || _unitOfWorkManager.Current == null)
        //    {
        //        return Task.CompletedTask;
        //    }

        //    return _unitOfWorkManager.Current.SaveChangesAsync();
        //}

        #region IQueryableUserStore
        public IQueryable<User> Users => _userRepository.GetAll();
        public void Dispose()
        {

        }
        public Task<string> GetUserIdAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(User user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(User user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserLoginStore
        public Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(User user, string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserRoleStore
        public Task AddToRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(User user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserClaimStore
        public Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ReplaceClaimAsync(User user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(User user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserSecurityStampStore

        public Task SetSecurityStampAsync(User user, string stamp, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetSecurityStampAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserEmailStore

        public Task SetEmailAsync(User user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task SetNormalizedEmailAsync(User user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(User user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserPhoneNumberStore

        public Task SetPhoneNumberAsync(User user, string phoneNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPhoneNumberAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IUserTwoFactorStore

        public Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserAuthenticationTokenStore

        public Task SetTokenAsync(User user, string loginProvider, string name, string value, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetTokenAsync(User user, string loginProvider, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IUserAuthenticatorKeyStore

        public Task SetAuthenticatorKeyAsync(User user, string key, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAuthenticatorKeyAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
