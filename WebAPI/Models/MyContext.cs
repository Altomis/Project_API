using MySql.Data.MySqlClient.Memcached;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class MyContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<FinishedJobs> FinishedJobs { get; set; }
        public DbSet<FTP_Server> FTP_Server { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<ClientGroups> ClientGroups {get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Path> Path { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}