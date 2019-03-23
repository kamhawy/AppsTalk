using System;
using System.Collections.Generic;
using System.Data.Entity;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// Entity Repository Base
    /// </summary>
    [Serializable]
    public class EntityRepositoryBase<T> : RepositoryBase
        where T : DBEntityBase
    {
        #region Constructors

        public EntityRepositoryBase()
            : base()
        {

        }

        public EntityRepositoryBase(DbContext pDbContext)
            : base(pDbContext)
        {

        }

        #endregion

        #region Methods

        #region Get Entity

        /// <summary>
        /// Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public T GetEntity(GetDataRequest<T> pGetDataRequest)
        {
            T entity = default(T);

            try
            {
                entity = base.GetEntity<T>(pGetDataRequest);
            }
            catch { throw; }

            return entity;
        }

        /// <summary>
        /// Used to Get single entity of specified type
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <param name="pMergeOption"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public T GetEntity(int pEntityID, bool pNoTracking, params string[] pIncludes)
        {
            T entity = default(T);

            try
            {
                entity = base.GetEntity<T>(pEntityID, pNoTracking, pIncludes);
            }
            catch { throw; }

            return entity;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Used to Get object List of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> list = null;

            try
            {
                list = base.GetAll<T>();
            }
            catch { throw; }

            return list;
        }

        /// <summary>
        /// Used to Get object List of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(GetDataRequest<T> pGetDataRequest)
        {
            IEnumerable<T> list = null;

            try
            {
                list = base.GetAll<T>(pGetDataRequest);
            }
            catch { throw; }

            return list;
        }

        #endregion

        #region Operations

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="pEntity"></param>
        public void AddEntity(T pEntity)
        {
            try
            {
                base.AddEntity<T>(pEntity);
            }
            catch { throw; }
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="pEntities"></param>
        public void AddEntity(IEnumerable<T> pEntities)
        {
            try
            {
                base.AddEntity<T>(pEntities);
            }
            catch { throw; }
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        public int UpdateEntity(T pEntity)
        {
            int changes = 0;

            try
            {
                changes = base.UpdateEntity<T>(pEntity);
            }
            catch { throw; }

            return changes;
        }

        /// <summary>
        /// Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pEntity">Entity</param>
        public void ApplyEntityChanges(T pEntity)
        {
            try
            {
                base.ApplyEntityChanges<T>(pEntity);
            }
            catch { throw; }
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        public int DeleteEntity(T pEntity, bool pSaveChanges = true)
        {
            int changes = 0;

            try
            {
                changes = base.DeleteEntity<T>(pEntity, pSaveChanges);
            }
            catch { throw; }

            return changes;
        }

        /// <summary>
        /// Used to remove list of entities from the entity set in the context
        /// </summary>
        /// <param name="pEntities"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        public int DeleteEntityList(List<T> pEntities, bool pSaveChanges = true)
        {
            int changes = 0;

            try
            {
                changes = base.DeleteEntityList<T>(pEntities, pSaveChanges);
            }
            catch { throw; }

            return changes;
        }

        #endregion

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            base.DisposeManagedRessources();
        }

        #endregion
    }
}