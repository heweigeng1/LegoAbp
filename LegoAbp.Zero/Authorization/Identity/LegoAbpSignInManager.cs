using LegoAbp.Zero.Authorization.Users.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LegoAbp.Zero.Authorization.Identity
{
    public class LegoAbpSignInManager: SignInManager<User>
    {

        public LegoAbpSignInManager(
            LegoAbpUserManager userManager,
            IHttpContextAccessor httpContextAccessor, 
            LegoAbpUserClaimsPrincipalFactory legoAbpUserClaimsPrincipalFactory,
            IOptions<IdentityOptions>  options,
            ILogger<LegoAbpSignInManager> logger,
            IAuthenticationSchemeProvider schemes) 
            : base(userManager, httpContextAccessor, legoAbpUserClaimsPrincipalFactory, options, logger, schemes)
        {

        }
    }
}
