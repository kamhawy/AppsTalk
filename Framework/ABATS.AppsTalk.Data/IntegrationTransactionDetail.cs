using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ABATS.AppsTalk.Core;

namespace ABATS.AppsTalk.Data
{
    [Serializable]
    [DataContract(IsReference = true)]
    public partial class IntegrationTransactionDetail : DBEntityBase
    {
    	#region Overrides
    
    	/// <summary>
        /// Entity ID
        /// </summary>
        public override int EntityID
        {
            get 
            {
                return (int)this.IntegrationTransactionDetailID;
            }
        }
    
    	/// <summary>
        /// Entity Key
        /// </summary>
        public override string EntityKey
        {
            get 
            {
                return "IntegrationTransactionDetailID";
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
                return "IntegrationTransactionDetailID";
            }
        }
    
    	#endregion
    
    	#region Primitive Properties
    
    	private int _IntegrationTransactionDetailID;
    
    	[DataMember]
        public int IntegrationTransactionDetailID 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionDetailID;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionDetailID = value;
    			this.SendPropertyChanged("IntegrationTransactionDetailID");
    		}
    	}
    
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
    
    	private byte _IntegrationTransactionDetailStatus;
    
    	[DataMember]
        public byte IntegrationTransactionDetailStatus 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionDetailStatus;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionDetailStatus = value;
    			this.SendPropertyChanged("IntegrationTransactionDetailStatus");
    		}
    	}
    
    	private byte[] _IntegrationTransactionDetailData;
    
    	[DataMember]
        public byte[] IntegrationTransactionDetailData 
    	{ 
    		get
    		{
    			return this._IntegrationTransactionDetailData;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransactionDetailData = value;
    			this.SendPropertyChanged("IntegrationTransactionDetailData");
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
    
    	private IntegrationTransaction _IntegrationTransaction;
    
    	[DataMember]
        public virtual IntegrationTransaction IntegrationTransaction 
    	{ 
    		get
    		{
    			return this._IntegrationTransaction;
    		} 
    		set
    		{
    			this.SendPropertyChanging();
    			this._IntegrationTransaction = value;
    			this.SendPropertyChanged("IntegrationTransaction");
    		}
    	}
    
    	#endregion
    }
}
