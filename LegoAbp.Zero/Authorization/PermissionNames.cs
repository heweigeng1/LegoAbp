namespace LegoAbp.Zero.Authorization
{
    /// <summary>
    /// 权限
    /// </summary>
    public static class PermissionNames
    {
        #region 用户User
        public const string User_Create = "User.Create";
        public const string User_Delete = "User.Delete";
        public const string User_Update = "User.Update";
        public const string User_Page = "User.Page";
        /// <summary>
        /// 修改用户权限
        /// </summary>
        public const string UserRole_Update = "UserRole.Update";
        #endregion

        #region 租户Tenant
        public const string Tenant_Create = "Tenant.Create";
        public const string Tenant_Delete = "Tenant.Delete";
        public const string Tenant_Update = "Tenant.Update";
        public const string Tenant_Page = "Tenant.Page";
        /// <summary>
        /// 检验
        /// </summary>
        public const string Tenant_Reviewing = "Tenant.Reviewing";
        #endregion
    }
}
