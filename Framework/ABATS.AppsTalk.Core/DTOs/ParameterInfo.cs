using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Parameter Info
    /// </summary>
    [Serializable]
    public class ParameterInfo : DTOBase
    {
        #region Members

        private SystemParameter _SystemParameter =  SystemParameter.None;
        private string _ParameterValue = string.Empty;

        #endregion

        #region Properties

        [DataMember]
        public SystemParameter SystemParameter
        {
            get { return this._SystemParameter; }
            set { this._SystemParameter = value; }
        }

        [DataMember]
        public string ParameterValue
        {
            get { return this._ParameterValue; }
            set { this._ParameterValue = value; }
        }

        #endregion

        #region Constructors

        public ParameterInfo()
        {

        }

        public ParameterInfo(SystemParameter pSystemParameter, string pParameterValue)
        {
            this.SystemParameter = pSystemParameter;
            this.ParameterValue = pParameterValue;
        }

        #endregion
    }
}