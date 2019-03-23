using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class SystemGroup : DBEntityBase
    {
    	#region Constructor
    
        public SystemGroup()
        {
            this.SystemGroupObjects = new HashSet<SystemGroupObject>();
            this.SystemUserGroups = new HashSet<SystemUserGroup>();
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
                return (int)this.SystemGroupID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "SystemGroupID";
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
                return "SystemGroupID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _SystemGroupID;
    
    	[DataMember]
        public int SystemGroupID 
    	{ 
    		get
    		{
    			return this._SystemGroupID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemGroupID = value;
    			this.SendPropertyChanged("SystemGroupID");
    		}
    	}
    
    	private string _SystemGroupName;
    
    	[DataMember]
        public string SystemGroupName 
    	{ 
    		get
    		{
    			return this._SystemGroupName;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemGroupName = value;
    			this.SendPropertyChanged("SystemGroupName");
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
    
    	private ICollection<SystemUserGroup> _SystemUserGroups;
    
    	[DataMember]
        public virtual ICollection<SystemUserGroup> SystemUserGroups 
    	{ 
    		get
    		{
    			return this._SystemUserGroups;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUserGroups = value;
    			this.SendPropertyChanged("SystemUserGroups");
    		}
    	}
    
    	#endregion
    }
}
