#region

using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Security
{
    /// <summary>
    ///     ISecurityService
    /// </summary>
    public interface ISecurityService : IAppService
    {
        #region Properties

        /// <summary>
        ///     Current User
        /// </summary>
        UserInfo CurrentUser { get; }

        /// <summary>
        ///     Current User Name Or Default
        /// </summary>
        string CurrentUserNameOrDefault { get; }

        /// <summary>
        ///     Current User Full Name Or Default
        /// </summary>
        string CurrentUserFullNameOrDefault { get; }

        #endregion

        #region Methods

        ///// <summary>
        ///// Get User
        ///// </summary>
        ///// <param name="pUserName"></param>
        ///// <param name="pIncludeAll"></param>
        ///// <returns></returns>
        //ApplicationUser GetUser(string pUserName, bool pIncludeAll = true);

        ///// <summary>
        ///// Get User Info
        ///// </summary>
        ///// <param name="pUserName"></param>
        ///// <returns></returns>
        //UserInfo GetUserInfo(string pUserName);

        ///// <summary>
        ///// Get Current User
        ///// </summary>
        ///// <param name="pReload"></param>
        ///// <returns></returns>
        //UserInfo GetCurrentUser(bool pReload = true);

        ///// <summary>
        ///// Add User Track Page
        ///// </summary>
        ///// <param name="pApplicationRole"></param>
        ///// <param name="pUserID"></param>
        //void AddUserTrackPage(ApplicationRole pApplicationRole, string pUserID);

        ///// <summary>
        ///// Add User Track Page
        ///// </summary>
        ///// <param name="pApplicationRolePath"></param>
        ///// <param name="pUserID"></param>
        //void AddUserTrackPage(string pApplicationRolePath, string pUserID);

        ///// <summary>
        ///// Check User Authorization
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <param name="pApplicationRolePath"></param>
        ///// <param name="pAddUserTrack"></param>
        ///// <returns></returns>
        //bool CheckUserAuthorization(UserInfo pUser, string pApplicationRolePath, bool pAddUserTrack = true);

        ///// <summary>
        ///// Check User Authorization
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <param name="pApplicationRole"></param>
        ///// <param name="pAddUserTrack"></param>
        ///// <returns></returns>
        //bool CheckUserAuthorization(UserInfo pUser, ApplicationRole pApplicationRole, bool pAddUserTrack = true);

        ///// <summary>
        ///// Get User Roles
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <returns></returns>
        //List<ApplicationRole> GetUserRoles(UserInfo pUser);

        ///// <summary>
        ///// Get User Menu
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <returns></returns>
        //List<ApplicationMenu> GetUserMenu(UserInfo pUser);

        #endregion
    }
}