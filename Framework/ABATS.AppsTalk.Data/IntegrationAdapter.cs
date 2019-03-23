using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationAdapter : DBEntityBase
    {
    	#region Constructor
    
        public IntegrationAdapter()
        {
            this.IntegrationAdapterFields = new HashSet<IntegrationAdapterField>();
            this.IntegrationProcesses = new HashSet<IntegrationProcess>();
            this.IntegrationProcesses1 = new HashSet<IntegrationProcess>();
            this.IntegrationAdapterCaches = new HashSet<IntegrationAdapterCach>();
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
                return (int)this.IntegrationAdapterID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationAdapterID";
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
                return "IntegrationAdapterID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationAdapterID;
    
    	[DataMember]
        public int IntegrationAdapterID 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterID = value;
    			this.SendPropertyChanged("IntegrationAdapterID");
    		}
    	}
    
    	private string _IntegrationAdapterTitle;
    
    	[DataMember]
        public string IntegrationAdapterTitle 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterTitle = value;
    			this.SendPropertyChanged("IntegrationAdapterTitle");
    		}
    	}
    
    	private int _IntegrationAdapterType;
    
    	[DataMember]
        public int IntegrationAdapterType 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterType = value;
    			this.SendPropertyChanged("IntegrationAdapterType");
    		}
    	}
    
    	private Nullable<byte> _EndPointType;
    
    	[DataMember]
        public Nullable<byte> EndPointType 
    	{ 
    		get
    		{
    			return this._EndPointType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._EndPointType = value;
    			this.SendPropertyChanged("EndPointType");
    		}
    	}
    
    	private Nullable<int> _ApplicationDatabaseQueryID;
    
    	[DataMember]
        public Nullable<int> ApplicationDatabaseQueryID 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQueryID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQueryID = value;
    			this.SendPropertyChanged("ApplicationDatabaseQueryID");
    		}
    	}
    
    	private Nullable<int> _ApplicationWebServiceRequestID;
    
    	[DataMember]
        public Nullable<int> ApplicationWebServiceRequestID 
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
    
    	private ApplicationDatabaseQuery _ApplicationDatabaseQuery;
    
    	[DataMember]
        public virtual ApplicationDatabaseQuery ApplicationDatabaseQuery 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQuery;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQuery = value;
    			this.SendPropertyChanged("ApplicationDatabaseQuery");
    		}
    	}
    
    	private ApplicationWebServiceRequest _ApplicationWebServiceRequest;
    
    	[DataMember]
        public virtual ApplicationWebServiceRequest ApplicationWebServiceRequest 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceRequest;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceRequest = value;
    			this.SendPropertyChanged("ApplicationWebServiceRequest");
    		}
    	}
    
    	private ICollection<IntegrationAdapterField> _IntegrationAdapterFields;
    
    	[DataMember]
        public virtual ICollection<IntegrationAdapterField> IntegrationAdapterFields 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterFields;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterFields = value;
    			this.SendPropertyChanged("IntegrationAdapterFields");
    		}
    	}
    
    	private ICollection<IntegrationProcess> _IntegrationProcesses;
    
    	[DataMember]
        public virtual ICollection<IntegrationProcess> IntegrationProcesses 
    	{ 
    		get
    		{
    			return this._IntegrationProcesses;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcesses = value;
    			this.SendPropertyChanged("IntegrationProcesses");
    		}
    	}
    
    	private ICollection<IntegrationProcess> _IntegrationProcesses1;
    
    	[DataMember]
        public virtual ICollection<IntegrationProcess> IntegrationProcesses1 
    	{ 
    		get
    		{
    			return this._IntegrationProcesses1;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcesses1 = value;
    			this.SendPropertyChanged("IntegrationProcesses1");
    		}
    	}
    
    	private ICollection<IntegrationAdapterCach> _IntegrationAdapterCaches;
    
    	[DataMember]
        public virtual ICollection<IntegrationAdapterCach> IntegrationAdapterCaches 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterCaches;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterCaches = value;
    			this.SendPropertyChanged("IntegrationAdapterCaches");
    		}
    	}
    
    	#endregion
    }
}
