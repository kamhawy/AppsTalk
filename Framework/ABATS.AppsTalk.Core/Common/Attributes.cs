using System;
using System.Runtime.Serialization;

namespace ABATS.AppsTalk.Core
{
    /// <summary>
    /// Represents Month Attribute
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.All)]
    public sealed class MonthAttribute : Attribute
    {
        #region Members

        private int _MonthNo = 1;
        private string _MonthSymbol = string.Empty;
        private string _MonthName = string.Empty;
        private string _FormatedName = string.Empty;
        #endregion

        #region Properties

        /// <summary>
        /// Month No
        /// </summary>
        [DataMember]
        public int MonthNo
        {
            get
            {
                return _MonthNo;
            }
            private set
            {
                _MonthNo = value;
            }
        }

        /// <summary>
        /// Month Symbol
        /// </summary>
        [DataMember]
        public string MonthSymbol
        {
            get
            {
                return _MonthSymbol;
            }
            private set
            {
                _MonthSymbol = value;
            }
        }

        /// <summary>
        /// Month Name
        /// </summary>
        [DataMember]
        public string MonthName
        {
            get
            {
                return _MonthName;
            }
            private set
            {
                _MonthName = value;
            }
        }

        /// <summary>
        /// Formated Name
        /// </summary>
        [DataMember]
        public string FormatedName
        {
            get
            {
                return _FormatedName;
            }
            private set
            {
                _FormatedName = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of Month Attribute
        /// </summary>
        /// <param name="monthNo">Month No</param>
        /// <param name="monthSymbol">Month Symbol</param>
        /// <param name="monthName">Month Name</param>
        /// <param name="formatedName">Formated Name</param>
        public MonthAttribute(int monthNo, string monthSymbol, string monthName, string formatedName)
            : base()
        {
            MonthNo = monthNo;
            MonthSymbol = monthSymbol;
            MonthName = monthName;
            FormatedName = formatedName;
        }

        #endregion
    }

    /// <summary>
    /// Represents KeyValue Attribute
    /// </summary>
    [Serializable]
    [AttributeUsage(AttributeTargets.All)]
    public sealed class KeyValueAttribute : Attribute
    {
        #region Members

        private string _Key = string.Empty;
        private string _Value = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Key
        /// </summary>
        [DataMember]
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        /// <summary>
        /// Value
        /// </summary>
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of KeyValue Attribute
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        public KeyValueAttribute(string pKey, string pValue)
            : base()
        {
            Key = pKey;
            Value = pValue;
        }

        #endregion
    }
}