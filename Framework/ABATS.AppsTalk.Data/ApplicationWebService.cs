using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class ApplicationWebService : DBEntityBase
    {
    	#region Constructor
    
        public ApplicationWebService()
        {
            this.ApplicationWebServiceRequests = new HashSet<ApplicationWebServiceRequest>();
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
                return (int)this.ApplicationWebServiceID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "ApplicationWebServiceID";
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
                return "ApplicationWebServiceID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
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
    
    	private int _ApplicationID;
    
    	[DataMember]
        public int ApplicationID 
    	{ 
    		get
    		{
    			return this._ApplicationID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationID = value;
    			this.SendPropertyChanged("ApplicationID");
    		}
    	}
    
    	private string _ApplicationWebServiceTitle;
    
    	[DataMember]
        public string ApplicationWebServiceTitle 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceTitle = value;
    			this.SendPropertyChanged("ApplicationWebServiceTitle");
    		}
    	}
    
    	private string _ApplicationWebServiceURL;
    
    	[DataMember]
        public string ApplicationWebServiceURL 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceURL;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceURL = value;
    			this.SendPropertyChanged("ApplicationWebServiceURL");
    		}
    	}
    
    	private string _AssemblyFullPath;
    
    	[DataMember]
        public string AssemblyFullPath 
    	{ 
    		get
    		{
    			return this._AssemblyFullPath;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._AssemblyFullPath = value;
    			this.SendPropertyChanged("AssemblyFullPath");
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
    
    	private Application _Application;
    
    	[DataMember]
        public virtual Application Application 
    	{ 
    		get
    		{
    			return this._Application;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._Application = value;
    			this.SendPropertyChanged("Application");
    		}
    	}
    
    	private ICollection<ApplicationWebServiceRequest> _ApplicationWebServiceRequests;
    
    	[DataMember]
        public virtual ICollection<ApplicationWebServiceRequest> ApplicationWebServiceRequests 
    	{ 
    		get
    		{
    			return this._ApplicationWebServiceRequests;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServiceRequests = value;
    			this.SendPropertyChanged("ApplicationWebServiceRequests");
    		}
    	}
    
    	#endregion
    }
}
