using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationTransaction : DBEntityBase
    {
    	#region Constructor
    
        public IntegrationTransaction()
        {
            this.IntegrationTransactionDetails = new HashSet<IntegrationTransactionDetail>();
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
                return (int)this.IntegrationTransactionID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationTransactionID";
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
                return "IntegrationTransactionID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationTransactionID;
    
    	[DataMember]
        public int IntegrationTransactionID 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionID = value;
    			this.SendPropertyChanged("IntegrationTransactionID");
    		}
    	}
    
    	private string _IntegrationTransactionTitle;
    
    	[DataMember]
        public string IntegrationTransactionTitle 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionTitle;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionTitle = value;
    			this.SendPropertyChanged("IntegrationTransactionTitle");
    		}
    	}
    
    	private System.DateTime _IntegrationTransactionDate;
    
    	[DataMember]
        public System.DateTime IntegrationTransactionDate 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionDate;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionDate = value;
    			this.SendPropertyChanged("IntegrationTransactionDate");
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
    
    	private int _TransactionStatus;
    
    	[DataMember]
        public int TransactionStatus 
    	{ 
    		get
    		{
    			return this._TransactionStatus;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._TransactionStatus = value;
    			this.SendPropertyChanged("TransactionStatus");
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
    
    	private ICollection<IntegrationTransactionDetail> _IntegrationTransactionDetails;
    
    	[DataMember]
        public virtual ICollection<IntegrationTransactionDetail> IntegrationTransactionDetails 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionDetails;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionDetails = value;
    			this.SendPropertyChanged("IntegrationTransactionDetails");
    		}
    	}
    
    	#endregion
    }
}
