using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class SystemObject : DBEntityBase
    {
    	#region Constructor
    
        public SystemObject()
        {
            this.SystemGroupObjects = new HashSet<SystemGroupObject>();
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
                return (int)this.SystemObjectID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "SystemObjectID";
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
                return "SystemObjectID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _SystemObjectID;
    
    	[DataMember]
        public int SystemObjectID 
    	{ 
    		get
    		{
    			return this._SystemObjectID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemObjectID = value;
    			this.SendPropertyChanged("SystemObjectID");
    		}
    	}
    
    	private byte _SystemObjectType;
    
    	[DataMember]
        public byte SystemObjectType 
    	{ 
    		get
    		{
    			return this._SystemObjectType;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemObjectType = value;
    			this.SendPropertyChanged("SystemObjectType");
    		}
    	}
    
    	private string _SystemObjectIdentifier;
    
    	[DataMember]
        public string SystemObjectIdentifier 
    	{ 
    		get
    		{
    			return this._SystemObjectIdentifier;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemObjectIdentifier = value;
    			this.SendPropertyChanged("SystemObjectIdentifier");
    		}
    	}
    
    	private bool _IsActive;
    
    	[DataMember]
        public bool IsActive 
    	{ 
    		get
    		{
    			return this._IsActive;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IsActive = value;
    			this.SendPropertyChanged("IsActive");
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
    
    	private int _CreationUserID;
    
    	[DataMember]
        public int CreationUserID 
    	{ 
    		get
    		{
    			return this._CreationUserID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._CreationUserID = value;
    			this.SendPropertyChanged("CreationUserID");
    		}
    	}
    
    	private System.DateTime _CreationDate;
    
    	[DataMember]
        public System.DateTime CreationDate 
    	{ 
    		get
    		{
    			return this._CreationDate;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._CreationDate = value;
    			this.SendPropertyChanged("CreationDate");
    		}
    	}
    
    	private int _LastUpdateUserID;
    
    	[DataMember]
        public int LastUpdateUserID 
    	{ 
    		get
    		{
    			return this._LastUpdateUserID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._LastUpdateUserID = value;
    			this.SendPropertyChanged("LastUpdateUserID");
    		}
    	}
    
    	private System.DateTime _LastUpdate;
    
    	[DataMember]
        public System.DateTime LastUpdate 
    	{ 
    		get
    		{
    			return this._LastUpdate;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._LastUpdate = value;
    			this.SendPropertyChanged("LastUpdate");
    		}
    	}
    
    	#endregion
    	
    	#region Navigation Properties
    
    	private ICollection<SystemGroupObject> _SystemGroupObjects;
    
    	[DataMember]
        public virtual ICollection<SystemGroupObject> SystemGroupObjects 
    	{ 
    		get
    		{
    			return this._SystemGroupObjects;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemGroupObjects = value;
    			this.SendPropertyChanged("SystemGroupObjects");
    		}
    	}
    
    	#endregion
    }
}
