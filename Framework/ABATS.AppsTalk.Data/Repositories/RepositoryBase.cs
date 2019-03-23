using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// Repository Base
    /// </summary>
    [Serializable]
    public abstract class RepositoryBase : DisposableBase, IRepository
    {
        #region Members

        [NonSerialized]
        private DbContext _DataContext = null;
        private Guid _RepositoryID = Guid.Empty;

        #endregion

        #region Properties

        internal Guid RepositoryID
        {
            get
            {
                if (this._RepositoryID == Guid.Empty)
                {
                    this._RepositoryID = Guid.NewGuid();
                }

                return this._RepositoryID;
            }
        }

        internal DbContext DataContext
        {
            get
            {
                if (this._DataContext == null)
                {
                    this._DataContext = EFManager.Instance.GetDbContext(WebUtilities.GetCurrentUserName());
                }

                return this._DataContext;
            }
            set
            {
                this._DataContext = value;
            }
        }

        internal ObjectContext WrappedObjectContext
        {
            get
            {
                if (this._DataContext != null)
                {
                    return (this._DataContext as IObjectContextAdapter).ObjectContext;
                }
                else
                {
                    return null;
                }
            }
        }

        #endregion

        #region Constructors

        public RepositoryBase()
        {

        }

        public RepositoryBase(DbContext pDataContext)
        {
            this.DataContext = pDataContext;
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
        public T GetEntity<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            T entity = default(T);

            try
            {
                IQueryable<T> query = this.BuildQuery<T>(pGetDataRequest);

                if (query != null)
                {
                    entity = query.FirstOrDefault();
                }
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
        public T GetEntity<T>(int pEntityID, bool pNoTracking, params string[] pIncludes) where T : DBEntityBase
        {
            T entity = default(T);

            try
            {
                IQueryable<T> objQuery = this.BuildQuery<T>(null, pNoTracking, pIncludes);

                if (objQuery != null)
                {
                    entity = objQuery.Where(string.Format("{0} == @0", EFUtilities.GetEntityKeyName<T>(this.DataContext)), pEntityID).FirstOrDefault();
                }

            }
            catch { throw; }

            return entity;
        }

        /// <summary>
        /// Used to Get object using the key information
        /// </summary>
        /// <param name="pEntitySetName"></param>
        /// <param name="pKeyName"></param>
        /// <param name="pKeyValue"></param>
        /// <returns></returns>
        public object GetEntity(string pEntitySetName, string pKeyName, object pKeyValue)
        {
            object obj = null;

            try
            {
                if (this.DataContext != null)
                {
                    EntityKey entityKey = new EntityKey(this.DataContext.GetQualifiedEntitySetName(pEntitySetName),
                        pKeyName, pKeyValue);

                    this.WrappedObjectContext.TryGetObjectByKey(entityKey, out obj);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return obj;
        }

        #endregion

        #region Get All

        /// <summary>
        /// Used to Get object List of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : DBEntityBase
        {
            IEnumerable<T> list = null;

            try
            {
                list = GetAll(GetDataRequest<T>.Default());
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
        public IEnumerable<T> GetAll<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            IEnumerable<T> list = null;

            try
            {
                IQueryable<T> query = this.BuildQuery(pGetDataRequest);

                if (query != null)
                {
                    list = query.ToList();
                }
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
        public void AddEntity<T>(T pEntity) where T : DBEntityBase
        {
            try
            {
                DbSet<T> objSet = this.DataContext.Set<T>();

                if (objSet != null)
                {
                    objSet.Add(pEntity);
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <param name="pEntities"></param>
        public void AddEntity<T>(IEnumerable<T> pEntities) where T : DBEntityBase
        {
            try
            {
                DbSet<T> objSet = this.DataContext.Set<T>();

                if (objSet != null)
                {
                    foreach (T entity in pEntities)
                    {
                        objSet.Add(entity);
                    }
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        public int UpdateEntity<T>(T pEntity) where T : DBEntityBase
        {
            int changes = 0;

            try
            {
                this.ApplyEntityChanges(pEntity);
                changes = this.SaveChanges();
            }
            catch { throw; }

            return changes;
        }

        /// <summary>
        /// Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pEntity">Entity</param>
        public void ApplyEntityChanges<T>(T pEntity) where T : DBEntityBase
        {
            try
            {
                this.DataContext.ApplyEntityChanges<T>(pEntity);
            }
            catch { throw; }
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        public int DeleteEntity<T>(T pEntity, bool pSaveChanges = true) where T : DBEntityBase
        {
            int changes = 0;

            try
            {
                DbSet<T> dbSet = this.DataContext.Set<T>();

                if (dbSet != null)
                {
                    dbSet.Remove(pEntity);

                    if (pSaveChanges)
                    {
                        changes = this.SaveChanges();
                    }
                }
            }
            catch { throw; }

            return changes;
        }

        /// <summary>
        /// Used to remove list of entities from the entity set in the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        public int DeleteEntityList<T>(List<T> pEntities, bool pSaveChanges = true) where T : DBEntityBase
        {
            int changes = 0;

            try
            {
                foreach (T entity in pEntities)
                {
                    this.DeleteEntity<T>(entity, false);
                }

                if (pSaveChanges)
                {
                    changes = this.SaveChanges();
                }
            }
            catch { throw; }

            return changes;
        }

        /// <summary>
        /// Save Changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            int changes = 0;

            try
            {
                changes = this.DataContext.SaveChanges();
            }
            catch { throw; }

            return changes;
        }

        #endregion

        #region Query Builders

        /// <summary>
        /// Build Query
        /// </summary>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public IQueryable<T> BuildQuery<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            IQueryable<T> query = null;

            try
            {
                if (string.IsNullOrEmpty(pGetDataRequest.SQLWhere))
                {
                    query = this.BuildQuery(
                        pGetDataRequest.Where,
                        pGetDataRequest.DataRequestType == DataRequestType.NoTracking ? true : false,
                        pGetDataRequest.Includes);
                }
                else
                {
                    query = this.BuildSQLQuery<T>(
                           pGetDataRequest.SQLWhere,
                           pGetDataRequest.DataRequestType == DataRequestType.NoTracking ? true : false,
                           pGetDataRequest.Includes);
                }
            }
            catch { throw; }

            return query;
        }

        /// <summary>
        /// Build Query
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pAsNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public IQueryable<T> BuildQuery<T>(Expression<Func<T, bool>> pWhere, bool pAsNoTracking, params string[] pIncludes) where T : DBEntityBase
        {
            IQueryable<T> query = null;

            try
            {
                DbQuery<T> dbQuery = this.DataContext.Set<T>();

                if (dbQuery != null)
                {
                    if (pAsNoTracking)
                    {
                        dbQuery = dbQuery.AsNoTracking();
                    }

                    if (pIncludes != null)
                    {
                        foreach (string strInclude in pIncludes)
                        {
                            if (!string.IsNullOrEmpty(strInclude) && !string.IsNullOrEmpty(strInclude.Trim()))
                            {
                                dbQuery = dbQuery.Include(strInclude);
                            }
                        }
                    }

                    if (pWhere != null)
                    {
                        dbQuery = dbQuery.Where(pWhere) as DbQuery<T>;
                    }

                    //LogManager.LogMessage(dbQuery.ToString());

                    query = dbQuery;
                }
            }
            catch { throw; }

            return query;
        }

        /// <summary>
        /// Build Query
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pAsNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public IQueryable<T> BuildSQLQuery<T>(string pWhere, bool pAsNoTracking, params string[] pIncludes) where T : DBEntityBase
        {
            IQueryable<T> query = null;

            try
            {
                DbQuery<T> dbQuery = this.DataContext.Set<T>();

                if (dbQuery != null)
                {
                    if (pAsNoTracking)
                    {
                        dbQuery = dbQuery.AsNoTracking();
                    }

                    if (pIncludes != null)
                    {
                        foreach (string strInclude in pIncludes)
                        {
                            dbQuery = dbQuery.Include(strInclude);
                        }
                    }

                    if (pWhere != null)
                    {
                        dbQuery = dbQuery.Where(pWhere) as DbQuery<T>;
                    }

                    query = dbQuery;
                }
            }
            catch { throw; }

            return query;
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