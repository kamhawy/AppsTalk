using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Linq;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// Entity Framework Utilities
    /// </summary>
    public static class EFUtilities
    {
        #region Entity Utilities

        /// <summary>
        /// GetEntityKeyName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObjectContext"></param>
        /// <returns></returns>
        public static string GetEntityKeyName<T>(IObjectContextAdapter pObjectContext) where T : class
        {
            string keyName = string.Empty;

            ObjectSet<T> objSet = pObjectContext.ObjectContext.CreateObjectSet<T>();

            if (objSet != null)
            {
                EdmMember entitySetKeyMember = objSet.EntitySet.ElementType.KeyMembers.FirstOrDefault();

                if (entitySetKeyMember != null)
                {
                    keyName = entitySetKeyMember.Name;
                }
            }

            return keyName;
        }

        #endregion
    }
}