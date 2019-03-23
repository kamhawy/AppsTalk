using System;
using System.Linq;
using System.Reflection;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// DTO Utilities
    /// </summary>
    public static class DTOUtilities
    {
        #region DTO Utilities

        /// <summary>
        /// Map DTO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public static U MapDTO<T, U>(T pEntity)
            where T : class
            where U : DTOBase
        {
            U dto = null;

            try
            {
                if (pEntity != null)
                {
                    dto = Activator.CreateInstance<U>();

                    PropertyInfo[] propertiesDTO = dto.GetType().GetProperties();

                    foreach (PropertyInfo propEntity in pEntity.GetType().GetProperties())
                    {
                        PropertyInfo propDTO = propertiesDTO.FirstOrDefault(c => c.Name == propEntity.Name);

                        if (propDTO != null)
                        {
                            if (propDTO.PropertyType == propEntity.PropertyType)
                            {
                                propDTO.SetValue(dto, propEntity.GetValue(pEntity, null), null);
                            }
                            else
                            {
                                //Not the same 'Property Type'
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return dto;
        }

        ///// <summary>
        ///// Build User Info
        ///// </summary>
        ///// <param name="pUserName"></param>
        ///// <param name="pDBUser"></param>
        ///// <returns></returns>
        //public static UserInfo BuildUserInfo(string pUserName, ApplicationUser pDBUser)
        //{
        //    UserInfo userInfo = null;

        //    try
        //    {
        //        if (pDBUser != null)
        //        {
        //            userInfo = DTOUtilities.MapDTO<ApplicationUser, UserInfo>(pDBUser);
        //        }
        //        else
        //        {
        //            userInfo = new UserInfo() { FullName = pUserName };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogManager.LogException(ex);
        //    }

        //    return userInfo;
        //}

        #endregion
    }
}