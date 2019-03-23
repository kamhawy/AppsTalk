using System.Data.Entity;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// EF Extensions
    /// </summary>
    public static class EFExtensions
    {
        #region DbContext

        /// <summary>
        /// Returns a Full Qualified EntitySet Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pDbContext"></param>
        /// <returns></returns>
        public static string GetQualifiedEntitySetName<T>(this DbContext pDbContext) where T : DBEntityBase
        {
            ObjectContext context = (pDbContext as IObjectContextAdapter).ObjectContext;

            return string.Format("{0}.{1}", context.DefaultContainerName, context.CreateObjectSet<T>().EntitySet.Name);
        }

        /// <summary>
        /// Returns a Full Qualified EntitySet Name
        /// </summary>
        /// <param name="pDbContext"></param>
        /// <param name="pEntitySetName"></param>
        /// <returns></returns>
        public static string GetQualifiedEntitySetName(this DbContext pDbContext, string pEntitySetName)
        {
            ObjectContext context = (pDbContext as IObjectContextAdapter).ObjectContext;

            return string.Format("{0}.{1}", context.DefaultContainerName, pEntitySetName);
        }

        /// <summary>
        /// Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pDbContext">DB Context</param>
        /// <param name="pEntity">Entity</param>
        public static void ApplyEntityChanges<T>(this DbContext pDbContext, T pEntity) where T : class
        {
            object original = null;

            try
            {
                if (pEntity != null)
                {
                    DbEntityEntry<T> entry = pDbContext.Entry<T>(pEntity);

                    if (entry != null && entry.State == EntityState.Detached)
                    {
                        ObjectContext objectContext = (pDbContext as IObjectContextAdapter).ObjectContext;
                        ObjectSet<T> objectSet = objectContext.CreateObjectSet<T>();
                        EntityKey entitySetKey = objectSet.BuildEntityKey(pEntity);

                        if (objectContext.TryGetObjectByKey(entitySetKey, out original))
                        {
                            objectContext.ApplyCurrentValues(objectSet.GetEntitySetFullName(), pEntity);
                        }
                    }
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Is Context Dirty
        /// </summary>
        /// <param name="pDbContext"></param>
        /// <returns></returns>
        public static bool IsContextDirty(this DbContext pDbContext)
        {
            bool isDirty = false;

            try
            {
                ObjectContext objectContext = (pDbContext as IObjectContextAdapter).ObjectContext;

                isDirty = objectContext.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Added | EntityState.Deleted | EntityState.Modified).Any();
            }
            catch { throw; }

            return isDirty;
        }

        #endregion

        #region ObjectSet

        /// <summary>
        /// Get Entity Set Full Name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObjectSet"></param>
        /// <returns></returns>
        public static string GetEntitySetFullName<T>(this ObjectSet<T> pObjectSet) where T : class
        {
            return string.Format("{0}.{1}",
                pObjectSet.Context.DefaultContainerName,
                pObjectSet.EntitySet.Name);
        }

        /// <summary>
        /// Build Entity Key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pObjectSet"></param>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public static EntityKey BuildEntityKey<T>(this ObjectSet<T> pObjectSet, T pEntity) where T : class
        {
            EntityKey entitySetKey = null;

            try
            {
                string entitySetFullName = pObjectSet.GetEntitySetFullName();
                EdmMember entitySetKeyMember = pObjectSet.EntitySet.ElementType.KeyMembers.FirstOrDefault();

                if (entitySetKeyMember != null)
                {
                    object entityID = pEntity.GetPropertyValue(entitySetKeyMember.Name);

                    if (entityID != null)
                    {
                        entitySetKey = new EntityKey(entitySetFullName, entitySetKeyMember.Name, entityID);
                    }
                }
            }
            catch { throw; }

            return entitySetKey;
        }

        #endregion
    }
}