namespace BITOJ.Core.Authorization
{
    using NativeUserGroup = BITOJ.Data.Entities.UserGroup;

    /// <summary>
    /// 编码用户组。
    /// </summary>
    public enum UserGroup : int
    {
        /// <summary>
        /// 访客用户组。
        /// </summary>
        Guests = NativeUserGroup.Guests,

        /// <summary>
        /// 标准用户组。
        /// </summary>
        Standard = NativeUserGroup.Standard,

        /// <summary>
        /// 内部成员用户组。
        /// </summary>
        Insiders = NativeUserGroup.Insiders,

        /// <summary>
        /// 管理员用户组。
        /// </summary>
        Administrators = NativeUserGroup.Administrators,
    }
}
