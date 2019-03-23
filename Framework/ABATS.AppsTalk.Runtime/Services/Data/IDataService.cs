#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Data;

#endregion

namespace ABATS.AppsTalk.Runtime.Services.Data
{
    /// <summary>
    ///     IDataService
    /// </summary>
    public interface IDataService : IAppService
    {
        #region Get Entity

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        T GetEntity<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <param name="pEntityId"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        T GetEntity<T>(int pEntityId, params string[] pIncludes) where T : DBEntityBase;

        /// <summary>
        ///     Used to Get single entity of specified type
        /// </summary>
        /// <param name="pEntityId"></param>
        /// <param name="pNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        T GetEntity<T>(int pEntityId, bool pNoTracking = false, params string[] pIncludes) where T : DBEntityBase;

        #endregion

        #region Get All

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : DBEntityBase;

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        #endregion

        #region Operations

        /// <summary>
        ///     Is Context Dirty
        /// </summary>
        bool IsContextDirty { get; }

        /// <summary>
        ///     Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        void AddEntity<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        ///     Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        void AddEntity<T>(IEnumerable<T> pEntities) where T : DBEntityBase;

        /// <summary>
        ///     Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        int UpdateEntity<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        ///     Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pEntity">Entity</param>
        void ApplyEntityChanges<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        ///     Delete Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        int DeleteEntity<T>(T pEntity, bool pSaveChanges = true) where T : DBEntityBase;

        /// <summary>
        ///     Used to remove list of entities from the entity set in the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        int DeleteEntityList<T>(List<T> pEntities, bool pSaveChanges = true) where T : DBEntityBase;

        /// <summary>
        ///     Build Query
        /// </summary>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        IQueryable<T> BuildQuery<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        /// <summary>
        ///     Build Query
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pAsNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        IQueryable<T> BuildQuery<T>(Expression<Func<T, bool>> pWhere, bool pAsNoTracking, params string[] pIncludes)
            where T : DBEntityBase;

        /// <summary>
        ///     Get Generic Data Repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        EntityRepositoryBase<T> GetGenericDataRepository<T>() where T : DBEntityBase;

        /// <summary>
        ///     Save Changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion
    }
}