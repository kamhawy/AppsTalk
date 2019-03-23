using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class Application : DBEntityBase
    {
    	#region Constructor
    
        public Application()
        {
            this.ApplicationDatabases = new HashSet<ApplicationDatabas>();
            this.ApplicationWebServices = new HashSet<ApplicationWebService>();
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
                return (int)this.ApplicationID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "ApplicationID";
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
                return "ApplicationID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
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
    
    	private string _ApplicationSymbol;
    
    	[DataMember]
        public string ApplicationSymbol 
    	{ 
    		get
    		{
    			return this._ApplicationSymbol;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationSymbol = value;
    			this.SendPropertyChanged("ApplicationSymbol");
    		}
    	}
    
    	private string _ApplicationTitle;
    
    	[DataMember]
        public string ApplicationTitle 
    	{ 
    		get
    		{
    			return this._ApplicationTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationTitle = value;
    			this.SendPropertyChanged("ApplicationTitle");
    		}
    	}
    
    	private string _ApplicationVersion;
    
    	[DataMember]
        public string ApplicationVersion 
    	{ 
    		get
    		{
    			return this._ApplicationVersion;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationVersion = value;
    			this.SendPropertyChanged("ApplicationVersion");
    		}
    	}
    
    	private string _ApplicationProvider;
    
    	[DataMember]
        public string ApplicationProvider 
    	{ 
    		get
    		{
    			return this._ApplicationProvider;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationProvider = value;
    			this.SendPropertyChanged("ApplicationProvider");
    		}
    	}
    
    	private string _ApplicationBuisnessArea;
    
    	[DataMember]
        public string ApplicationBuisnessArea 
    	{ 
    		get
    		{
    			return this._ApplicationBuisnessArea;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationBuisnessArea = value;
    			this.SendPropertyChanged("ApplicationBuisnessArea");
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
    
    	private ICollection<ApplicationDatabas> _ApplicationDatabases;
    
    	[DataMember]
        public virtual ICollection<ApplicationDatabas> ApplicationDatabases 
    	{ 
    		get
    		{
    			return this._ApplicationDatabases;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationDatabases = value;
    			this.SendPropertyChanged("ApplicationDatabases");
    		}
    	}
    
    	private ICollection<ApplicationWebService> _ApplicationWebServices;
    
    	[DataMember]
        public virtual ICollection<ApplicationWebService> ApplicationWebServices 
    	{ 
    		get
    		{
    			return this._ApplicationWebServices;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._ApplicationWebServices = value;
    			this.SendPropertyChanged("ApplicationWebServices");
    		}
    	}
    
    	#endregion
    }
}
