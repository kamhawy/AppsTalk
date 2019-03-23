using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;
using ABATS.AppsTalk.Runtime;

namespace ABATS.AppsTalk.UX
{
    /// <summary>
    /// Entity Presenter Base
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class EntityPresenterBase<T> : PresenterBase, INotifyPropertyChanged
        where T : DBEntityBase
    {
        #region Members

        private string _EntityKey = string.Empty;
        private T _Entity = null;

        #endregion

        #region Properties

        [DataMember]
        public int EntityID
        {
            get
            {
                int _CurrentEntityID = -1;

                if (!string.IsNullOrEmpty(this.EntityKey))
                {
                    _CurrentEntityID = WebUtilities.GetObjectFromQueryString(this.EntityKey).SafeIntegerParse();
                }

                return _CurrentEntityID;
            }
        }

        [DataMember]
        public string EntityKey
        {
            get
            {
                if (string.IsNullOrEmpty(this._EntityKey))
                {
                    T objTemp = Activator.CreateInstance<T>();

                    if (objTemp != null)
                    {
                        this._EntityKey = objTemp.EntityKey;
                        objTemp = null;
                    }
                }

                return this._EntityKey;
            }
        }

        [DataMember]
        public T Entity
        {
            get
            {
                if (this.IsEntityChnaged(this._Entity))
                {
                    this._Entity = this.GetEntity(this.EntityID);

                    if (this._Entity != null)
                    {
                        AdjustEntity(this._Entity);
                    }
                }

                return this._Entity;
            }
            set
            {
                this._Entity = value;
            }
        }

        #region Virtuals

        [DataMember]
        public virtual string[] Includes
        {
            get { return null; }
        }

        #endregion

        #endregion

        #region Constructors

        public EntityPresenterBase()
            : base()
        {

        }

        public EntityPresenterBase(IAppRuntime pAppRuntime)
            : base(pAppRuntime)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Current Entity
        /// </summary>
        /// <returns></returns>
        public virtual T GetEntity(int pEntityID)
        {
            T entity = default(T);

            try
            {
                if (pEntityID > 0)
                {
                    entity = this.AppRuntime.DataService.GetEntity<T>(pEntityID, this.Includes);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return entity;
        }

        /// <summary>
        /// Load Current Entity
        /// </summary>
        /// <param name="pEntityID"></param>
        /// <returns></returns>
        public T LoadCurrentEntity(int pEntityID = -1)
        {
            this._Entity = null;

            try
            {
                int entityId = pEntityID > -1 ? pEntityID : this.EntityID;

                if (entityId > 0)
                {
                    this._Entity = base.AppRuntime.DataService.GetEntity<T>(entityId, this.Includes);

                    if (this._Entity != null)
                    {
                        AdjustEntity(this._Entity);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return this._Entity;
        }

        /// <summary>
        /// Invert Entity IsActive
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public bool InvertEntityIsActive(T pEntity)
        {
            bool success = false;

            try
            {
                pEntity.IsActiveEntity = !pEntity.IsActiveEntity;
                success = base.AppRuntime.DataService.UpdateEntity(pEntity) > 0;
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return success;
        }

        /// <summary>
        /// Adjust Entity
        /// </summary>
        /// <param name="pEntity"></param>
        public virtual void AdjustEntity(T pEntity)
        {

        }

        #region ObjectDataSource

        #region Insert

        /// <summary>
        /// Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int InsertEntity(T pEntity)
        {
            int results = 0;

            try
            {
                if (BeforeUpdateEntity(pEntity))
                {
                    base.AppRuntime.DataService.AddEntity(pEntity);
                    results = base.AppRuntime.DataService.SaveChanges();

                    AfterUpdateEntity(pEntity, results);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Before Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public virtual bool BeforeInsertEntity(T pEntity)
        {
            return true;
        }

        /// <summary>
        /// After Insert Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pResult"></param>
        /// <returns></returns>
        public virtual void AfterInsertEntity(T pEntity, int pResult)
        {

        }

        #endregion

        #region Update

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public int UpdateEntity(T pEntity)
        {
            int results = 0;

            try
            {
                if (BeforeUpdateEntity(pEntity))
                {
                    results = base.AppRuntime.DataService.UpdateEntity(pEntity);

                    AfterUpdateEntity(pEntity, results);
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return results;
        }

        /// <summary>
        /// Before Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        public virtual bool BeforeUpdateEntity(T pEntity)
        {
            return true;
        }

        /// <summary>
        /// After Update Entity
        /// </summary>
        /// <param name="pEntity"></param>
        /// <param name="pResult"></param>
        /// <returns></returns>
        public virtual void AfterUpdateEntity(T pEntity, int pResult)
        {

        }

        #endregion

        #endregion

        #endregion

        #region Helpers

        /// <summary>
        /// Is Entity Chnaged
        /// </summary>
        /// <param name="pEntity"></param>
        /// <returns></returns>
        private bool IsEntityChnaged(T pEntity)
        {
            bool changed = false;

            try
            {
                if (pEntity != null)
                {
                    if (this.EntityID > 0)
                    {
                        if (pEntity.EntityID != this.EntityID)
                        {
                            changed = true;
                        }
                    }
                }
                else
                {
                    changed = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.LogException(ex);
            }

            return changed;
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            this._EntityKey = null;
            this._Entity = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}