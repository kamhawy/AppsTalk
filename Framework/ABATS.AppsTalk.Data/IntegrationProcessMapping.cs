using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationProcessMapping : DBEntityBase
    {
    	#region Overrides
    
    	/// <summary>
        /// Entity ID
        /// </summary>
        public override int EntityID
        {
            get 
            {
                return (int)this.IntegrationProcessMappingID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationProcessMappingID";
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
                return "IntegrationProcessMappingID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationProcessMappingID;
    
    	[DataMember]
        public int IntegrationProcessMappingID 
    	{ 
    		get
    		{
    			return this._IntegrationProcessMappingID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessMappingID = value;
    			this.SendPropertyChanged("IntegrationProcessMappingID");
    		}
    	}
    
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
    
    	private int _SourceIntegrationAdapterFieldID;
    
    	[DataMember]
        public int SourceIntegrationAdapterFieldID 
    	{ 
    		get
    		{
    			return this._SourceIntegrationAdapterFieldID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SourceIntegrationAdapterFieldID = value;
    			this.SendPropertyChanged("SourceIntegrationAdapterFieldID");
    		}
    	}
    
    	private int _DestinationIntegrationAdapterFieldID;
    
    	[DataMember]
        public int DestinationIntegrationAdapterFieldID 
    	{ 
    		get
    		{
    			return this._DestinationIntegrationAdapterFieldID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._DestinationIntegrationAdapterFieldID = value;
    			this.SendPropertyChanged("DestinationIntegrationAdapterFieldID");
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
    
    	private IntegrationAdapterField _DestinationIntegrationAdapterField;
    
    	[DataMember]
        public virtual IntegrationAdapterField DestinationIntegrationAdapterField 
    	{ 
    		get
    		{
    			return this._DestinationIntegrationAdapterField;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._DestinationIntegrationAdapterField = value;
    			this.SendPropertyChanged("DestinationIntegrationAdapterField");
    		}
    	}
    
    	private IntegrationAdapterField _SourceIntegrationAdapterField;
    
    	[DataMember]
        public virtual IntegrationAdapterField SourceIntegrationAdapterField 
    	{ 
    		get
    		{
    			return this._SourceIntegrationAdapterField;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SourceIntegrationAdapterField = value;
    			this.SendPropertyChanged("SourceIntegrationAdapterField");
    		}
    	}
    
    	private IntegrationProcess _IntegrationProcess;
    
    	[DataMember]
        public virtual IntegrationProcess IntegrationProcess 
    	{ 
    		get
    		{
    			return this._IntegrationProcess;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcess = value;
    			this.SendPropertyChanged("IntegrationProcess");
    		}
    	}
    
    	#endregion
    }
}
