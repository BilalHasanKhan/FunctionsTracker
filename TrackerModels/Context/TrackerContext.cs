using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using TrackerModels.Models;

namespace TrackerModels.Context
{
   public class TrackerContext : DbContext 
    {
        public DbSet<ACR> ACR { get; set; }
        public DbSet<Applications> Applications { get; set; }
        public DbSet<AssetDetails> AssetDetails { get; set; }
        public DbSet<DocumentAttachment> DocumentAttachment { get; set; }
        public DbSet<OrgDetails> OrgDetails { get; set; }
        public DbSet<RFC> RFC { get; set; }
        public DbSet<AssigneeMapping> AssigneeMapping { get; set; }
        public DbSet<ServerDetails> ServerDetails { get; set; }
        public DbSet<ServerIPMapping> ServerIPMappings { get; set; }
        public DbSet<SoftwareDetails> SoftwareDetails { get; set; }
        public DbSet<StakeHolderMaster> StakeHolderMaster { get; set; }
        public DbSet<StakeHolderMapping> StakeHolderMapping { get; set; }
        public DbSet<StatusMaster> StatusMaster { get; set; }
        public DbSet<URLDetails> URLDetails { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<IncidentRequestMapping> IncidentRequestMapping { get; set; }
        public DbSet<ServiceRequestMapping> ServiceRequestMapping { get; set; }
        public DbSet<ServerAppMapping> ServerAppMapping { get; set; }

    }
}
