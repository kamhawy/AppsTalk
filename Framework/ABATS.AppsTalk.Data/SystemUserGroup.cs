using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class SystemUserGroup : DBEntityBase
    {
    	#region Overrides
    
    	/// <summary>
        /// Entity ID
        /// </summary>
        public override int EntityID
        {
            get 
            {
                return (int)this.SystemUserGroupID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "SystemUserGroupID";
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
                return "SystemUserGroupID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _SystemUserGroupID;
    
    	[DataMember]
        public int SystemUserGroupID 
    	{ 
    		get
    		{
    			return this._SystemUserGroupID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUserGroupID = value;
    			this.SendPropertyChanged("SystemUserGroupID");
    		}
    	}
    
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
    
    	private SystemGroup _SystemGroup;
    
    	[DataMember]
        public virtual SystemGroup SystemGroup 
    	{ 
    		get
    		{
    			return this._SystemGroup;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemGroup = value;
    			this.SendPropertyChanged("SystemGroup");
    		}
    	}
    
    	private SystemUser _SystemUser;
    
    	[DataMember]
        public virtual SystemUser SystemUser 
    	{ 
    		get
    		{
    			return this._SystemUser;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._SystemUser = value;
    			this.SendPropertyChanged("SystemUser");
    		}
    	}
    
    	#endregion
    }
}
