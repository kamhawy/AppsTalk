using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationAdapterField : DBEntityBase
    {
    	#region Constructor
    
        public IntegrationAdapterField()
        {
            this.IntegrationProcessMappings = new HashSet<IntegrationProcessMapping>();
            this.IntegrationProcessMappings1 = new HashSet<IntegrationProcessMapping>();
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
                return (int)this.IntegrationAdapterFieldID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationAdapterFieldID";
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
                return "IntegrationAdapterFieldID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationAdapterFieldID;
    
    	[DataMember]
        public int IntegrationAdapterFieldID 
    	{ 
    		get
    		{
    			return this._IntegrationAdapterFieldID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationAdapterFieldID = value;
    			this.SendPropertyChanged("IntegrationAdapterFieldID");
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
    
    	private int _FieldCategory;
    
    	[DataMember]
        public int FieldCategory 
    	{ 
    		get
    		{
    			return this._FieldCategory;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._FieldCategory = value;
    			this.SendPropertyChanged("FieldCategory");
    		}
    	}
    
    	private string _FieldName;
    
    	[DataMember]
        public string FieldName 
    	{ 
    		get
    		{
    			return this._FieldName;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._FieldName = value;
    			this.SendPropertyChanged("FieldName");
    		}
    	}
    
    	private int _FieldDataType;
    
    	[DataMember]
        public int FieldDataType 
    	{ 
    		get
    		{
    			return this._FieldDataType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._FieldDataType = value;
    			this.SendPropertyChanged("FieldDataType");
    		}
    	}
    
    	private bool _IsPrimaryKey;
    
    	[DataMember]
        public bool IsPrimaryKey 
    	{ 
    		get
    		{
    			return this._IsPrimaryKey;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IsPrimaryKey = value;
    			this.SendPropertyChanged("IsPrimaryKey");
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
    
    	private byte _PrimaryKeySequence;
    
    	[DataMember]
        public byte PrimaryKeySequence 
    	{ 
    		get
    		{
    			return this._PrimaryKeySequence;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._PrimaryKeySequence = value;
    			this.SendPropertyChanged("PrimaryKeySequence");
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
    
    	private ICollection<IntegrationProcessMapping> _IntegrationProcessMappings1;
    
    	[DataMember]
        public virtual ICollection<IntegrationProcessMapping> IntegrationProcessMappings1 
    	{ 
    		get
    		{
    			return this._IntegrationProcessMappings1;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationProcessMappings1 = value;
    			this.SendPropertyChanged("IntegrationProcessMappings1");
    		}
    	}
    
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
