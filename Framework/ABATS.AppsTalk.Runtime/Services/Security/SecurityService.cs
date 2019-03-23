#region

using System;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Security
{
    /// <summary>
    ///     Security Service
    /// </summary>
    [Serializable]
    internal class SecurityService : AppServiceBase, ISecurityService
    {
        #region Members

        private UserInfo _currentUser;

        #endregion

        #region Constructor

        internal SecurityService(IAppRuntime pIAppRuntime)
            : base(pIAppRuntime)
        {
        }

        #endregion

        #region IRuntimeService

        public bool Initialize()
        {
            bool success = false;

            try
            {
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        #endregion

        #region ISecurityService

        #region Properties

        [DataMember]
        public UserInfo CurrentUser
        {
            get { return _currentUser ?? (_currentUser = new UserInfo(Constants.SystemUser)); }
            private set { _currentUser = value; }
        }

        [DataMember]
        public string CurrentUserNameOrDefault
        {
            get { return CurrentUser != null ? CurrentUser.UserName : Constants.SystemUser; }
        }

        [DataMember]
        public string CurrentUserFullNameOrDefault
        {
            get { return CurrentUser != null ? CurrentUser.FullName : Constants.SystemUser; }
        }

        #endregion

        #region Methods

        ///// <summary>
        ///// Get User
        ///// </summary>
        ///// <param name="pUserName"></param>
        ///// <param name="pIncludeAll"></param>
        ///// <returns></returns>
        //public ApplicationUser GetUser(string pUserName, bool pIncludeAll = true)
        //{
        //    ApplicationUser user = null;

        //    try
        //    {
        //        List<string> includes = new List<string>();

        //        if (pIncludeAll)
        //        {
        //            includes.Add("ApplicationUserInGroups.ApplicationGroup.ApplicationGroupInRoles.ApplicationRole.ApplicationRoleUsersAccess");
        //        }
        //        else
        //        {
        //            includes.Add("ApplicationUserInGroups.ApplicationGroup");
        //            includes.Add("ApplicationUserCCSIs.CCSI");
        //            includes.Add("ApplicationUserLicenses.License");
        //        }

        //        user = base.AppRuntime.DataService.GetEntity(GetDataRequest<ApplicationUser>.Create(
        //            c => c.UserName == pUserName, includes.ToArray()));
        //    }
        //    catch { throw; }

        //    return user;
        //}

        ///// <summary>
        ///// Get User Info
        ///// </summary>
        ///// <returns></returns>
        //public UserInfo GetUserInfo(string pUserName)
        //{
        //    UserInfo userInfo = null;

        //    try
        //    {
        //        userInfo = DTOUtilities.BuildUserInfo(pUserName, this.GetUser(pUserName, false));
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return userInfo;
        //}

        ///// <summary>
        ///// Get Current User
        ///// </summary>
        ///// <param name="pReload"></param>
        ///// <returns></returns>
        //public UserInfo GetCurrentUser(bool pReload = true)
        //{
        //    if (pReload)
        //    {
        //        this.CurrentUser = null;
        //    }

        //    return this.CurrentUser;
        //}

        ///// <summary>
        ///// Add User Track Page
        ///// </summary>
        ///// <param name="pApplicationRole"></param>
        ///// <param name="pUserID"></param>
        //public void AddUserTrackPage(ApplicationRole pApplicationRole, string pUserID)
        //{
        //    try
        //    {
        //        if (pApplicationRole != null)
        //        {
        //            ApplicationRoleUsersAccess appRoleUserAccesss = new ApplicationRoleUsersAccess()
        //            {
        //                ApplicationRoleID = pApplicationRole.ApplicationRoleID,
        //                ApplicationUserID = pUserID,
        //                AccessDateTime = DateTime.Now,
        //            };

        //            base.AppRuntime.DataService.AddEntity(appRoleUserAccesss);
        //            base.AppRuntime.DataService.SaveChanges();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }
        //}

        ///// <summary>
        ///// Add User Track Page
        ///// </summary>
        ///// <param name="pApplicationRolePath"></param>
        ///// <param name="pUserID"></param>
        //public void AddUserTrackPage(string pApplicationRolePath, string pUserID)
        //{
        //    try
        //    {
        //        ApplicationRole appRole = base.AppRuntime.MetadataService.GetRole(pApplicationRolePath);

        //        if (appRole != null)
        //        {
        //            this.AddUserTrackPage(appRole, pUserID);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }
        //}

        ///// <summary>
        ///// Check User Authorization
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <param name="pApplicationRolePath"></param>
        ///// <param name="pAddUserTrack"></param>
        ///// <returns></returns>
        //public bool CheckUserAuthorization(UserInfo pUser, string pApplicationRolePath, bool pAddUserTrack = true)
        //{
        //    bool isAuthorized = false;

        //    try
        //    {
        //        ApplicationRole appRole = base.AppRuntime.MetadataService.GetRole(pApplicationRolePath);

        //        if (appRole != null)
        //        {
        //            isAuthorized = this.CheckUserAuthorization(pUser, appRole, pAddUserTrack);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return isAuthorized;
        //}

        ///// <summary>
        ///// Check User Authorization
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <param name="pApplicationRole"></param>
        ///// <param name="pAddUserTrack"></param>
        ///// <returns></returns>
        //public bool CheckUserAuthorization(UserInfo pUser, ApplicationRole pApplicationRole, bool pAddUserTrack = true)
        //{
        //    bool isAuthorized = false;

        //    try
        //    {
        //        if (pApplicationRole != null)
        //        {
        //            foreach (ApplicationGroupInRole appGroup in pApplicationRole.ApplicationGroupInRoles.Where(c => c.ApplicationGroup.IsActiveDirectoryGroup == false))
        //            {
        //                ApplicationUserInGroup appGroupUser = appGroup.ApplicationGroup.ApplicationUserInGroups.FirstOrDefault(c =>
        //                    c.ApplicationUser.UserName.ToLower() == pUser.UserName.ToLower());

        //                if (appGroupUser != null)
        //                {
        //                    isAuthorized = true;
        //                    break;
        //                }
        //            }

        //            if (pAddUserTrack)
        //            {
        //                this.AddUserTrackPage(pApplicationRole, pUser.UserName);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return isAuthorized;
        //}

        ///// <summary>
        ///// Get User Roles
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <returns></returns>
        //public List<ApplicationRole> GetUserRoles(UserInfo pUser)
        //{
        //    List<ApplicationRole> roles = null;

        //    try
        //    {
        //        roles = new List<ApplicationRole>();

        //        foreach (ApplicationRole appRole in base.AppRuntime.MetadataService.Roles)
        //        {
        //            foreach (ApplicationGroupInRole appGroup in appRole.ApplicationGroupInRoles)
        //            {
        //                ApplicationUserInGroup appGroupUser = appGroup.ApplicationGroup.ApplicationUserInGroups.FirstOrDefault(c =>
        //                    c.ApplicationUser.UserName.ToLower() == pUser.UserName);

        //                if (appGroupUser != null)
        //                {
        //                    roles.Add(appRole);
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return roles;
        //}

        ///// <summary>
        ///// Get User Menu
        ///// </summary>
        ///// <param name="pUser"></param>
        ///// <returns></returns>
        //public List<ApplicationMenu> GetUserMenu(UserInfo pUser)
        //{
        //    List<ApplicationMenu> menus = null;

        //    try
        //    {
        //        menus = new List<ApplicationMenu>();
        //        List<ApplicationRole> userRoles = this.GetUserRoles(pUser);

        //        foreach (ApplicationMenu menuModule in base.AppRuntime.MetadataService.Menus.Where(c => c.IsModuleRoot).OrderBy(c => c.DisplaySequence))
        //        {
        //            bool pAddModule = false;

        //            foreach (ApplicationMenu menuGroup in menuModule.Items.OrderBy(c => c.DisplaySequence))
        //            {
        //                bool pAddGroup = false;

        //                foreach (ApplicationMenu menuRole in menuGroup.Items.OrderBy(c => c.DisplaySequence))
        //                {
        //                    ApplicationRole appRole = userRoles.FirstOrDefault(c => c.ApplicationRoleID == menuRole.ApplicationRoleID);

        //                    if (appRole != null)
        //                    {
        //                        pAddModule = true;
        //                        pAddGroup = true;

        //                        menus.Add(menuRole);
        //                    }
        //                }

        //                if (pAddGroup)
        //                {
        //                    menus.Add(menuGroup);
        //                }
        //            }

        //            if (pAddModule)
        //            {
        //                menus.Add(menuModule);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return menus;
        //}

        #endregion

        #endregion

        #region Factory

        internal static ISecurityService Create(IAppRuntime pIAppRuntime)
        {
            return new SecurityService(pIAppRuntime);
        }

        #endregion
    }
}