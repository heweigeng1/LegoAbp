using Abp.Authorization;

namespace LegoAbp.Zero.Authorization
{
    public class LegoAbpZeroAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.User_Create);
            context.CreatePermission(PermissionNames.User_Delete);
            context.CreatePermission(PermissionNames.User_Update);
            context.CreatePermission(PermissionNames.User_Page);
            context.CreatePermission(PermissionNames.UserRole_Update);

            context.CreatePermission(PermissionNames.Tenant_Create);
            context.CreatePermission(PermissionNames.Tenant_Update);
            context.CreatePermission(PermissionNames.Tenant_Delete);
            context.CreatePermission(PermissionNames.Tenant_Reviewing);
        }
    }
}
