using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationAdapterCach : DBEntityBase
    {
    	#region Overrides
    
    	/// <summary>
        /// Entity ID
        /// </summary>
        public override int EntityID
        {
            get 
            {
                return (int)this.IntegrationAdapterCacheID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationAdapterCacheID";
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
                return "IntegrationAdapterCacheID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationAdapterCacheID;
    
    	[DataMember]
        public int IntegrationAdapterCacheID 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterCacheID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterCacheID = value;
    			this.SendPropertyChanged("IntegrationAdapterCacheID");
    		}
    	}
    
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
    
    	private string _CachePrimaryKeys;
    
    	[DataMember]
        public string CachePrimaryKeys 
    	{ 
    		get
    		{
    			return this._CachePrimaryKeys;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._CachePrimaryKeys = value;
    			this.SendPropertyChanged("CachePrimaryKeys");
    		}
    	}
    
    	private byte _CacheStatus;
    
    	[DataMember]
        public byte CacheStatus 
    	{ 
    		get
    		{
    			return this._CacheStatus;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._CacheStatus = value;
    			this.SendPropertyChanged("CacheStatus");
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
    
    	private IntegrationAdapter _IntegrationAdapter;
    
    	[DataMember]
        public virtual IntegrationAdapter IntegrationAdapter 
    	{ 
    		get
    		{
    			return this._IntegrationAdapter;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapter = value;
    			this.SendPropertyChanged("IntegrationAdapter");
    		}
    	}
    
    	#endregion
    }
}
