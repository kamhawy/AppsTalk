#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Data
{
    /// <summary>
    ///     Data Service
    /// </summary>
    [Serializable]
    internal class DataService : AppServiceBase, IDataService
    {
        #region Members

        [NonSerialized] private DbContext _dataContext;
        private List<RepositoryBase> _genericRepositories;

        #endregion

        #region Properties

        internal DbContext DataContext
        {
            get {
                return _dataContext ??
                       (_dataContext = EFManager.Instance.GetDbContext(WebUtilities.GetCurrentUserName()));
            }
            set { _dataContext = value; }
        }

        internal List<RepositoryBase> GenericRepositories
        {
            get { return _genericRepositories ?? (_genericRepositories = new List<RepositoryBase>()); }
            private set { _genericRepositories = value; }
        }

        #endregion

        #region Constructor

        internal DataService(IAppRuntime pIAppRuntime)
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

        #region IDataService

        #region Get Entity

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public T GetEntity<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            T entity = default(T);

            try
            {
                entity = GetGenericDataRepository<T>().GetEntity(pGetDataRequest);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntityId"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public T GetEntity<T>(int pEntityId, params string[] pIncludes) where T : DBEntityBase
        {
            T entity = default(T);

            try
            {
                entity = GetEntity<T>(pEntityId, false, pIncludes);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntityId"></param>
        /// <param name="pNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public T GetEntity<T>(int pEntityId, bool pNoTracking = false, params string[] pIncludes) where T : DBEntityBase
        {
            T entity = default(T);

            try
            {
                entity = GetGenericDataRepository<T>().GetEntity(pEntityId, pNoTracking, pIncludes);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        ///     Used to Get object using the Entity Set Name and the key information
        /// </summary>
        /// <param name="pEntitySetName"></param>
        /// <param name="pKeyName"></param>
        /// <param name="pKeyValue"></param>
        /// <returns></returns>
        public object GetEntity(string pEntitySetName, string pKeyName, object pKeyValue)
        {
            object entity = null;

            try
            {
                //entity = this.GetGenericDataRepository<T>().GetEntity(pEntityID, pNoTracking, pIncludes);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        #endregion

        #region Get All

        /// <summary>
        ///     Get All
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>() where T : DBEntityBase
        {
            IEnumerable<T> entities = default(IEnumerable<T>);

            try
            {
                entities = GetGenericDataRepository<T>().GetAll().ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entities;
        }

        /// <summary>
        ///     Get All
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            IEnumerable<T> entities = default(IEnumerable<T>);

            try
            {
                entities = GetGenericDataRepository<T>().GetAll(pGetDataRequest).ToList();
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entities;
        }

        #endregion

        #region Operations

        /// <summary>
        ///     Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        public void AddEntity<T>(T pEntity) where T : DBEntityBase
        {
            try
            {
                GetGenericDataRepository<T>().AddEntity(pEntity);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        ///     Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        public void AddEntity<T>(IEnumerable<T> pEntities) where T : DBEntityBase
        {
            try
            {
                GetGenericDataRepository<T>().AddEntity(pEntities);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        ///     Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        public int UpdateEntity<T>(T pEntity) where T : DBEntityBase
        {
            int changes = 0;

            try
            {
                RepositoryBase repository = GetGenericDataRepository<T>();

                if (repository != null)
                {
                    changes = repository.UpdateEntity(pEntity);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return changes;
        }

        /// <summary>
        ///     Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pEntity">Entity</param>
        public void ApplyEntityChanges<T>(T pEntity) where T : DBEntityBase
        {
            try
            {
                GetGenericDataRepository<T>().ApplyEntityChanges(pEntity);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }
        }

        /// <summary>
        ///     Delete Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        /// <param name="pSaveChanges"></param>
        public int DeleteEntity<T>(T pEntity, bool pSaveChanges = true) where T : DBEntityBase
        {
            int changes = 0;

            try
            {
                changes = GetGenericDataRepository<T>().DeleteEntity(pEntity, pSaveChanges);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return changes;
        }

        /// <summary>
        ///     Used to remove list of entities from the entity set in the context
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
                changes = GetGenericDataRepository<T>().DeleteEntityList(pEntities, pSaveChanges);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return changes;
        }

        /// <summary>
        ///     Build Query
        /// </summary>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        public IQueryable<T> BuildQuery<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase
        {
            IQueryable<T> query = null;

            try
            {
                query = GetGenericDataRepository<T>().BuildQuery(pGetDataRequest);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return query;
        }

        /// <summary>
        ///     Build Query
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pAsNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        public IQueryable<T> BuildQuery<T>(Expression<Func<T, bool>> pWhere, bool pAsNoTracking,
            params string[] pIncludes) where T : DBEntityBase
        {
            IQueryable<T> query = null;

            try
            {
                query = GetGenericDataRepository<T>().BuildQuery(pWhere, pAsNoTracking, pIncludes);
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return query;
        }

        /// <summary>
        ///     Get Data Repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public EntityRepositoryBase<T> GetGenericDataRepository<T>() where T : DBEntityBase
        {
            EntityRepositoryBase<T> dataRepository = null;

            try
            {
                foreach (var ds in GenericRepositories)
                {
                    if (ds is EntityRepositoryBase<T>)
                    {
                        dataRepository = ds as EntityRepositoryBase<T>;
                        break;
                    }
                }

                if (dataRepository == null)
                {
                    dataRepository = new EntityRepositoryBase<T>(DataContext);

                    GenericRepositories.Add(dataRepository);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return dataRepository;
        }

        /// <summary>
        ///     Save Changes
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            int changes = 0;

            try
            {
                RepositoryBase firstRepository = GenericRepositories.FirstOrDefault();

                if (firstRepository != null)
                {
                    changes = firstRepository.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return changes;
        }

        /// <summary>
        ///     Is Context Dirty
        /// </summary>
        public bool IsContextDirty
        {
            get { return DataContext.IsContextDirty(); }
        }

        #endregion

        #endregion

        #region Factory

        internal static IDataService Create(IAppRuntime pIAppRuntime)
        {
            return new DataService(pIAppRuntime);
        }

        #endregion

        #region Disposable

        /// <summary>
        ///     Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            CoreUtilities.SafeDispose(ref _genericRepositories);

            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }

            base.DisposeManagedRessources();
        }

        #endregion
    }
}