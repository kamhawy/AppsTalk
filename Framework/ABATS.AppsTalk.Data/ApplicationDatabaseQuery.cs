using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class ApplicationDatabaseQuery : DBEntityBase
    {
    	#region Constructor
    
        public ApplicationDatabaseQuery()
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
                return (int)this.ApplicationDatabaseQueryID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "ApplicationDatabaseQueryID";
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
                return "ApplicationDatabaseQueryID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _ApplicationDatabaseQueryID;
    
    	[DataMember]
        public int ApplicationDatabaseQueryID 
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
    
    	private string _ApplicationDatabaseQueryTitle;
    
    	[DataMember]
        public string ApplicationDatabaseQueryTitle 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQueryTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQueryTitle = value;
    			this.SendPropertyChanged("ApplicationDatabaseQueryTitle");
    		}
    	}
    
    	private byte _ApplicationDatabaseQueryType;
    
    	[DataMember]
        public byte ApplicationDatabaseQueryType 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQueryType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQueryType = value;
    			this.SendPropertyChanged("ApplicationDatabaseQueryType");
    		}
    	}
    
    	private string _ApplicationDatabaseQueryCommand;
    
    	[DataMember]
        public string ApplicationDatabaseQueryCommand 
    	{ 
    		get
    		{
    			return this._ApplicationDatabaseQueryCommand;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabaseQueryCommand = value;
    			this.SendPropertyChanged("ApplicationDatabaseQueryCommand");
    		}
    	}
    
    	private bool _IsAsync;
    
    	[DataMember]
        public bool IsAsync 
    	{ 
    		get
    		{
    			return this._IsAsync;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IsAsync = value;
    			this.SendPropertyChanged("IsAsync");
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
    
    	private ApplicationDatabas _ApplicationDatabas;
    
    	[DataMember]
        public virtual ApplicationDatabas ApplicationDatabas 
    	{ 
    		get
    		{
    			return this._ApplicationDatabas;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabas = value;
    			this.SendPropertyChanged("ApplicationDatabas");
    		}
    	}
    
    	#endregion
    }
}
