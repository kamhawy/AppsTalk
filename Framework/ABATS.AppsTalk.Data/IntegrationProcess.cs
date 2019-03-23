using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationProcess : DBEntityBase
    {
    	#region Constructor
    
        public IntegrationProcess()
        {
            this.IntegrationProcessMappings = new HashSet<IntegrationProcessMapping>();
            this.IntegrationTransactions = new HashSet<IntegrationTransaction>();
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
                return (int)this.IntegrationProcessID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationProcessID";
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
                return "IntegrationProcessID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationProcessID;
    
    	[DataMember]
        public int IntegrationProcessID 
    	{ 
    		get
    		{
    			return this._IntegrationProcessID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessID = value;
    			this.SendPropertyChanged("IntegrationProcessID");
    		}
    	}
    
    	private string _IntegrationProcessCode;
    
    	[DataMember]
        public string IntegrationProcessCode 
    	{ 
    		get
    		{
    			return this._IntegrationProcessCode;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessCode = value;
    			this.SendPropertyChanged("IntegrationProcessCode");
    		}
    	}
    
    	private string _IntegrationProcessTitle;
    
    	[DataMember]
        public string IntegrationProcessTitle 
    	{ 
    		get
    		{
    			return this._IntegrationProcessTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessTitle = value;
    			this.SendPropertyChanged("IntegrationProcessTitle");
    		}
    	}
    
    	private Nullable<int> _SourceIntegrationAdapterID;
    
    	[DataMember]
        public Nullable<int> SourceIntegrationAdapterID 
    	{ 
    		get
    		{
    			return this._SourceIntegrationAdapterID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SourceIntegrationAdapterID = value;
    			this.SendPropertyChanged("SourceIntegrationAdapterID");
    		}
    	}
    
    	private Nullable<int> _DestinationIntegrationAdapterID;
    
    	[DataMember]
        public Nullable<int> DestinationIntegrationAdapterID 
    	{ 
    		get
    		{
    			return this._DestinationIntegrationAdapterID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._DestinationIntegrationAdapterID = value;
    			this.SendPropertyChanged("DestinationIntegrationAdapterID");
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
    
    	private ICollection<IntegrationProcessMapping> _IntegrationProcessMappings;
    
    	[DataMember]
        public virtual ICollection<IntegrationProcessMapping> IntegrationProcessMappings 
    	{ 
    		get
    		{
    			return this._IntegrationProcessMappings;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessMappings = value;
    			this.SendPropertyChanged("IntegrationProcessMappings");
    		}
    	}
    
    	private ICollection<IntegrationTransaction> _IntegrationTransactions;
    
    	[DataMember]
        public virtual ICollection<IntegrationTransaction> IntegrationTransactions 
    	{ 
    		get
    		{
    			return this._IntegrationTransactions;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactions = value;
    			this.SendPropertyChanged("IntegrationTransactions");
    		}
    	}
    
    	private IntegrationAdapter _DestinationIntegrationAdapter;
    
    	[DataMember]
        public virtual IntegrationAdapter DestinationIntegrationAdapter 
    	{ 
    		get
    		{
    			return this._DestinationIntegrationAdapter;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._DestinationIntegrationAdapter = value;
    			this.SendPropertyChanged("DestinationIntegrationAdapter");
    		}
    	}
    
    	private IntegrationAdapter _SourceIntegrationAdapter;
    
    	[DataMember]
        public virtual IntegrationAdapter SourceIntegrationAdapter 
    	{ 
    		get
    		{
    			return this._SourceIntegrationAdapter;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SourceIntegrationAdapter = value;
    			this.SendPropertyChanged("SourceIntegrationAdapter");
    		}
    	}
    
    	#endregion
    }
}
