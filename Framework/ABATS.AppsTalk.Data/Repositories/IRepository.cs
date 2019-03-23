using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    public interface IRepository : IDisposable
    {
        #region Get Entity

        /// <summary>
        /// Used to Get single entity of specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        T GetEntity<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        /// <summary>
        /// Used to Get single entity of specified type
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <param name="pNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        T GetEntity<T>(int pEntityID, bool pNoTracking = false, params string[] pIncludes) where T : DBEntityBase;

        /// <summary>
        /// Used to Get object using the key information
        /// </summary>
        /// <param name="pEntitySetName"></param>
        /// <param name="pKeyName"></param>
        /// <param name="pKeyValue"></param>
        /// <returns></returns>
        object GetEntity(string pEntitySetName, string pKeyName, object pKeyValue);

        #endregion

        #region Get All

        /// <summary>
        /// GetAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>() where T : DBEntityBase;

        /// <summary>
        /// GetAll
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        #endregion

        #region Operations

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        void AddEntity<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        /// Add Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        void AddEntity<T>(IEnumerable<T> pEntities) where T : DBEntityBase;

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        int UpdateEntity<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        /// Apply the changes made to a detached entity
        /// </summary>
        /// <param name="pEntity">Entity</param>
        void ApplyEntityChanges<T>(T pEntity) where T : DBEntityBase;

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntity"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        int DeleteEntity<T>(T pEntity, bool pSaveChanges = true) where T : DBEntityBase;

        /// <summary>
        /// Used to remove list of entities from the entity set in the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pEntities"></param>
        /// <param name="pSaveChanges"></param>
        /// <returns></returns>
        int DeleteEntityList<T>(List<T> pEntities, bool pSaveChanges = true) where T : DBEntityBase;

        /// <summary>
        /// Save Changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion

        #region Query Builders

        /// <summary>
        /// Build Query
        /// </summary>
        /// <param name="pGetDataRequest"></param>
        /// <returns></returns>
        IQueryable<T> BuildQuery<T>(GetDataRequest<T> pGetDataRequest) where T : DBEntityBase;

        /// <summary>
        /// Build Query
        /// </summary>
        /// <param name="pWhere"></param>
        /// <param name="pAsNoTracking"></param>
        /// <param name="pIncludes"></param>
        /// <returns></returns>
        IQueryable<T> BuildQuery<T>(Expression<Func<T, bool>> pWhere, bool pAsNoTracking, params string[] pIncludes) where T : DBEntityBase;

        #endregion
    }
}