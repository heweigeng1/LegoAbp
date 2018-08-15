using Microsoft.AspNetCore.Identity;

namespace LegoAbp.Zero.Authorization.Identity
{
    public static class IdentityResultExtensions
    {
        public static IdentityResult ToLocalize(this IdentityResult identityResult)
        {
            return identityResult;
        }
    }
}
