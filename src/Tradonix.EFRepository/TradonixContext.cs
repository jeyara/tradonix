using Tradonix.EFRepository;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tradonix.Core.Entities;
using Tradonix.EFRepository.Migrations;

namespace Tradonix.EFRepository
{
    public class TradonixContext:DbContext
    {
        public DbSet<LogEntry> LogEntry { get; set; }
        public DbSet<Setting> Setting { get; set; }

        public TradonixContext() : base("name=Tradonix")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TradonixContext, Configuration>());
            //new TradonixContext().Database.Initialize(false);

            if (!Database.Exists())
            {
                Database.CreateIfNotExists();
                DbInitializer.Initialize(this);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Log
            modelBuilder.Entity<LogEntry>().HasKey(m => m.Id);
            modelBuilder.Entity<LogEntry>().Property(m => m.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LogEntry>().Property(m => m.Timestamp).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.HostName).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.LogType).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.LogLevelId).IsRequired();
            modelBuilder.Entity<LogEntry>().Ignore(m => m.LogLevel);

            //Setting
            modelBuilder.Entity<Setting>().HasKey(s => s.Id);
            modelBuilder.Entity<Setting>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Setting>().Property(s => s.Key).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.Value).IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}
