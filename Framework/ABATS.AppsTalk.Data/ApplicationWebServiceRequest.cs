using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class ApplicationWebServiceRequest : DBEntityBase
    {
    	#region Constructor
    
        public ApplicationWebServiceRequest()
        {
            this.IntegrationAdapters = new HashSet<IntegrationAdapter>();
        }
    	
    	#endregion
    
    	#region Overrides
    
    	/// <summary>
        /// Entity ID
        /// </summary>
        public override int EntityID
        {
            get 
            {
                return (int)this.ApplicationWebServiceRequestID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "ApplicationWebServiceRequestID";
            }
        }
    
    	#endregion
    
    	#region Static Properties
    
    	/// <summary>
        /// Static Entity Key
        /// </summary>
        public static string sEntityKey
        {
            get 
            {
                return "ApplicationWebServiceRequestID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _ApplicationWebServiceRequestID;
    
    	[DataMember]
        public int ApplicationWebServiceRequestID 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceRequestID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceRequestID = value;
    			this.SendPropertyChanged("ApplicationWebServiceRequestID");
    		}
    	}
    
    	private int _ApplicationWebServiceID;
    
    	[DataMember]
        public int ApplicationWebServiceID 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceID = value;
    			this.SendPropertyChanged("ApplicationWebServiceID");
    		}
    	}
    
    	private string _ApplicationWebServiceRequestTitle;
    
    	[DataMember]
        public string ApplicationWebServiceRequestTitle 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceRequestTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceRequestTitle = value;
    			this.SendPropertyChanged("ApplicationWebServiceRequestTitle");
    		}
    	}
    
    	private byte _ApplicationWebServiceRequestType;
    
    	[DataMember]
        public byte ApplicationWebServiceRequestType 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceRequestType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceRequestType = value;
    			this.SendPropertyChanged("ApplicationWebServiceRequestType");
    		}
    	}
    
    	private string _ImplementationTypeFullName;
    
    	[DataMember]
        public string ImplementationTypeFullName 
    	{ 
    		get
    		{
    			return this._ImplementationTypeFullName;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ImplementationTypeFullName = value;
    			this.SendPropertyChanged("ImplementationTypeFullName");
    		}
    	}
    
    	private string _Description;
    
    	[DataMember]
        public string Description 
    	{ 
    		get
    		{
    			return this._Description;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._Description = value;
    			this.SendPropertyChanged("Description");
    		}
    	}
    
    	private int _RecordStatus;
    
    	[DataMember]
        public int RecordStatus 
    	{ 
    		get
    		{
    			return this._RecordStatus;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._RecordStatus = value;
    			this.SendPropertyChanged("RecordStatus");
    		}
    	}
    
    	private string _RecordCreatedBy;
    
    	[DataMember]
        public string RecordCreatedBy 
    	{ 
    		get
    		{
    			return this._RecordCreatedBy;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._RecordCreatedBy = value;
    			this.SendPropertyChanged("RecordCreatedBy");
    		}
    	}
    
    	private System.DateTime _RecordCreated;
    
    	[DataMember]
        public System.DateTime RecordCreated 
    	{ 
    		get
    		{
    			return this._RecordCreated;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._RecordCreated = value;
    			this.SendPropertyChanged("RecordCreated");
    		}
    	}
    
    	private string _RecordLastUpdateBy;
    
    	[DataMember]
        public string RecordLastUpdateBy 
    	{ 
    		get
    		{
    			return this._RecordLastUpdateBy;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._RecordLastUpdateBy = value;
    			this.SendPropertyChanged("RecordLastUpdateBy");
    		}
    	}
    
    	private System.DateTime _RecordLastUpdate;
    
    	[DataMember]
        public System.DateTime RecordLastUpdate 
    	{ 
    		get
    		{
    			return this._RecordLastUpdate;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._RecordLastUpdate = value;
    			this.SendPropertyChanged("RecordLastUpdate");
    		}
    	}
    
    	#endregion
    	
    	#region Navigation Properties
    
    	private ICollection<IntegrationAdapter> _IntegrationAdapters;
    
    	[DataMember]
        public virtual ICollection<IntegrationAdapter> IntegrationAdapters 
    	{ 
    		get
    		{
    			return this._IntegrationAdapters;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapters = value;
    			this.SendPropertyChanged("IntegrationAdapters");
    		}
    	}
    
    	private ApplicationWebService _ApplicationWebService;
    
    	[DataMember]
        public virtual ApplicationWebService ApplicationWebService 
    	{ 
    		get
    		{
    			return this._ApplicationWebService;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebService = value;
    			this.SendPropertyChanged("ApplicationWebService");
    		}
    	}
    
    	#endregion
    }
}
