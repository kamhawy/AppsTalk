using System;
using System.Collections.Generic;
using System.Data.Entity;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    /// <summary>
    /// EF Manager
    /// </summary>
    public class EFManager : SingletonBase<EFManager>
    {
        #region Members

        [NonSerialized]
        private Dictionary<string, DbContext> _DbContexts = null;
        private static readonly object _lockObj = new object();

        #endregion

        #region Properties

        /// <summary>
        /// Db Contexts
        /// </summary>
        public Dictionary<string, DbContext> DbContexts
        {
            get
            {
                if (this._DbContexts == null)
                {
                    this._DbContexts = new Dictionary<string, DbContext>();
                }

                return this._DbContexts;
            }
        }

        #endregion

        #region Singleton

        private EFManager()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Db Context
        /// </summary>
        /// <param name="pUser"></param>
        /// <returns></returns>
        public DbContext GetDbContext(string pUser)
        {
            DbContext context = null;

            lock (_lockObj)
            {
                if (this.DbContexts.ContainsKey(pUser))
                {
                    context = this.DbContexts[pUser];
                }
                else
                {
                    // Context Specification
                    context = new DBEntities();

                    this.DbContexts.Add(pUser, context);
                }
            }

            return context;
        }

        /// <summary>
        /// Remove DbContext
        /// </summary>
        /// <param name="pUser"></param>
        public void RemoveDbContext(string pUser)
        {
            lock (_lockObj)
            {
                if (this.DbContexts.ContainsKey(pUser))
                {
                    this.DbContexts.Remove(pUser);
                }
            }
        }

        #endregion
    }
}