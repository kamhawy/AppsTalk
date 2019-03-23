using System;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represent the constructed query for getting the data from the database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class GetDataRequest<T> : DisposableBase where T : DBEntityBase
    {
        #region Members

        private Expression<Func<T, bool>> _Where = null;
        private DataRequestType _DataRequestType = DataRequestType.OverwriteChanges;
        private string[] _Includes = null;
        private string _SQLWhere = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public Expression<Func<T, bool>> Where
        {
            get
            {
                return this._Where;
            }
            set
            {
                this._Where = value;
            }
        }

        [DataMember]
        public DataRequestType DataRequestType
        {
            get
            {
                return this._DataRequestType;
            }
            set
            {
                this._DataRequestType = value;
            }
        }

        [DataMember]
        public string[] Includes
        {
            get
            {
                if (this._Includes == null)
                {
                    this._Includes = new string[] { };
                }

                return this._Includes;
            }
            set
            {
                this._Includes = value;
            }
        }

        [DataMember]
        public string SQLWhere
        {
            get
            {
                return this._SQLWhere;
            }
            set
            {
                this._SQLWhere = value;
            }
        }

        #endregion

        #region Constructors

        public GetDataRequest()
        {

        }

        public GetDataRequest(params string[] pIncludes)
        {
            this.Includes = pIncludes;
        }

        public GetDataRequest(DataRequestType pDataRequestType, params string[] pIncludes)
        {
            this.DataRequestType = pDataRequestType;
            this.Includes = pIncludes;
        }

        public GetDataRequest(Expression<Func<T, bool>> pWhere, params string[] pIncludes)
        {
            this.Where = pWhere;
            this.Includes = pIncludes;
        }

        public GetDataRequest(Expression<Func<T, bool>> pWhere, DataRequestType pDataRequestType, params string[] pIncludes)
        {
            this.Where = pWhere;
            this.DataRequestType = pDataRequestType;
            this.Includes = pIncludes;
        }
        
        public static GetDataRequest<T> Default()
        {
            return new GetDataRequest<T>();
        }

        #endregion

        #region Factory

        public static GetDataRequest<T> Create()
        {
            return new GetDataRequest<T>();
        }

        public static GetDataRequest<T> Create(params string[] pIncludes)
        {
            return new GetDataRequest<T>(pIncludes);
        }

        public static GetDataRequest<T> Create(DataRequestType pDataRequestType, params string[] pIncludes)
        {
            return new GetDataRequest<T>(pDataRequestType, pIncludes);
        }

        public static GetDataRequest<T> Create(Expression<Func<T, bool>> pWhere, params string[] pIncludes)
        {
            return new GetDataRequest<T>(pWhere, pIncludes);
        }

        public static GetDataRequest<T> Create(Expression<Func<T, bool>> pWhere, DataRequestType pDataRequestType, params string[] pIncludes)
        {
            return new GetDataRequest<T>(pWhere, pDataRequestType, pIncludes);
        }

        #endregion

        #region Disposable

        /// <summary>
        /// Free Managed Ressources. Typically by calling Dispose on them
        /// </summary>
        protected override void DisposeManagedRessources()
        {
            _Where = null;
            _Includes = null;

            base.DisposeManagedRessources();
        }

        #endregion
    }
}