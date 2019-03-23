using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class ApplicationDatabas : DBEntityBase
    {
    	#region Constructor
    
        public ApplicationDatabas()
        {
            this.ApplicationDatabaseQueries = new HashSet<ApplicationDatabaseQuery>();
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
                return (int)this.ApplicationDatabaseID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "ApplicationDatabaseID";
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
                return "ApplicationDatabaseID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _ApplicationDatabaseID;
    
    	[DataMember]
        public int ApplicationDatabaseID 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseID = value;
    			this.SendPropertyChanged("ApplicationDatabaseID");
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
    
    	private string _ApplicationDatabaseTitle;
    
    	[DataMember]
        public string ApplicationDatabaseTitle 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseTitle = value;
    			this.SendPropertyChanged("ApplicationDatabaseTitle");
    		}
    	}
    
    	private int _ApplicationDatabaseType;
    
    	[DataMember]
        public int ApplicationDatabaseType 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseType = value;
    			this.SendPropertyChanged("ApplicationDatabaseType");
    		}
    	}
    
    	private string _Metadata;
    
    	[DataMember]
        public string Metadata 
    	{ 
    		get
    		{
    			return this._Metadata;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._Metadata = value;
    			this.SendPropertyChanged("Metadata");
    		}
    	}
    
    	private string _ProviderName;
    
    	[DataMember]
        public string ProviderName 
    	{ 
    		get
    		{
    			return this._ProviderName;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ProviderName = value;
    			this.SendPropertyChanged("ProviderName");
    		}
    	}
    
    	private string _ProviderConnectionString;
    
    	[DataMember]
        public string ProviderConnectionString 
    	{ 
    		get
    		{
    			return this._ProviderConnectionString;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ProviderConnectionString = value;
    			this.SendPropertyChanged("ProviderConnectionString");
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
    
    	private ICollection<ApplicationDatabaseQuery> _ApplicationDatabaseQueries;
    
    	[DataMember]
        public virtual ICollection<ApplicationDatabaseQuery> ApplicationDatabaseQueries 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQueries;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQueries = value;
    			this.SendPropertyChanged("ApplicationDatabaseQueries");
    		}
    	}
    
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
    
    	#endregion
    }
}
