using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ABATS.AppsTalk.Data
{
    public partial class DBEntities : DbContext
    {
    	#region Constructor
    
        public DBEntities()
            : base("name=DBEntities")
        {
    		this.Configuration.ProxyCreationEnabled = false;
    		this.Configuration.AutoDetectChangesEnabled = true;
        }
    
    	#endregion
    
    	#region DbSets
    
        public DbSet<IntegrationAdapterField> IntegrationAdapterFields { get; set; }
    
        public DbSet<IntegrationProcess> IntegrationProcesses { get; set; }
    
        public DbSet<IntegrationProcessMapping> IntegrationProcessMappings { get; set; }
    
        public DbSet<IntegrationTransactionDetail> IntegrationTransactionDetails { get; set; }
    
        public DbSet<IntegrationTransaction> IntegrationTransactions { get; set; }
    
        public DbSet<ApplicationDatabaseQuery> ApplicationDatabaseQueries { get; set; }
    
        public DbSet<ApplicationWebServiceRequest> ApplicationWebServiceRequests { get; set; }
    
        public DbSet<IntegrationAdapter> IntegrationAdapters { get; set; }
    
        public DbSet<ApplicationDatabas> ApplicationDatabases { get; set; }
    
        public DbSet<Application> Applications { get; set; }
    
        public DbSet<IntegrationAdapterCach> IntegrationAdapterCaches { get; set; }
    
        public DbSet<SystemGroupObject> SystemGroupObjects { get; set; }
    
        public DbSet<SystemGroup> SystemGroups { get; set; }
    
        public DbSet<SystemObject> SystemObjects { get; set; }
    
        public DbSet<SystemUserGroup> SystemUserGroups { get; set; }
    
        public DbSet<SystemUser> SystemUsers { get; set; }
    
        public DbSet<ApplicationWebService> ApplicationWebServices { get; set; }
    
    	#endregion
    }
}
