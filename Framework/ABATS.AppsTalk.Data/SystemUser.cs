using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class SystemUser : DBEntityBase
    {
    	#region Constructor
    
        public SystemUser()
        {
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
                return (int)this.SystemUserID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "SystemUserID";
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
                return "SystemUserID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _SystemUserID;
    
    	[DataMember]
        public int SystemUserID 
    	{ 
    		get
    		{
    			return this._SystemUserID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUserID = value;
    			this.SendPropertyChanged("SystemUserID");
    		}
    	}
    
    	private string _SystemUserNetworkID;
    
    	[DataMember]
        public string SystemUserNetworkID 
    	{ 
    		get
    		{
    			return this._SystemUserNetworkID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUserNetworkID = value;
    			this.SendPropertyChanged("SystemUserNetworkID");
    		}
    	}
    
    	private string _SystemUserFullName;
    
    	[DataMember]
        public string SystemUserFullName 
    	{ 
    		get
    		{
    			return this._SystemUserFullName;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUserFullName = value;
    			this.SendPropertyChanged("SystemUserFullName");
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
