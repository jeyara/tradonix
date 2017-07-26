using Tradonix.EFRepository;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Tradonix.Core.Entities;
using Tradonix.EFRepository.Migrations;
using Tradonix.Core.Entities.Meta;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;

namespace Tradonix.EFRepository
{
    public class TradonixContext:DbContext
    {
        public DbSet<LogEntry> LogEntry { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
        public DbSet<Ticker> Ticker { get; set; }
        public DbSet<ExchangeTicker> ExchangeTicker { get; set; }
        public DbSet<MarketSummary> MarketSummary { get; set; }

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

            modelBuilder.Entity<LogEntry>().HasKey(m => m.Id);
            modelBuilder.Entity<LogEntry>().Property(m => m.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<LogEntry>().Property(m => m.Timestamp).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.HostName).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.LogType).IsRequired();
            modelBuilder.Entity<LogEntry>().Property(m => m.LogLevelId).IsRequired();
            modelBuilder.Entity<LogEntry>().Ignore(m => m.LogLevel);

            modelBuilder.Entity<Setting>().HasKey(s => s.Id);
            modelBuilder.Entity<Setting>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Setting>().Property(s => s.Key).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.Value).IsRequired();

            modelBuilder.Entity<Exchange>().HasKey(s => s.Id);
            modelBuilder.Entity<Exchange>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Exchange>().Property(s => s.UniqueId).IsRequired();
            modelBuilder.Entity<Exchange>().Property(s => s.Name).IsRequired().HasMaxLength(1024);
            modelBuilder.Entity<Exchange>().Property(s => s.Url).IsRequired().HasMaxLength(2048);
            modelBuilder.Entity<Exchange>().Property(s => s.IsActive).IsRequired();
            modelBuilder.Entity<Exchange>().Property(s => s.AddedOn).IsRequired();
            modelBuilder.Entity<Exchange>().Property(s => s.AddedBy).IsRequired();
            modelBuilder.Entity<Exchange>().Property(s => s.UpdatedOn).IsOptional();
            modelBuilder.Entity<Exchange>().Property(s => s.UpdatedBy).IsOptional();

            modelBuilder.Entity<Ticker>().HasKey(s => s.Id);
            modelBuilder.Entity<Ticker>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Ticker>().Property(s => s.UniqueId).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.Code).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<Ticker>().Property(s => s.Name).IsRequired().HasMaxLength(1024);
            modelBuilder.Entity<Ticker>().Property(s => s.MinimumUnit).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.LogoUrl).IsOptional();
            modelBuilder.Entity<Ticker>().Property(s => s.TickerTypeId).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.IsActive).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.AddedOn).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.AddedBy).IsRequired();
            modelBuilder.Entity<Ticker>().Property(s => s.UpdatedOn).IsOptional();
            modelBuilder.Entity<Ticker>().Property(s => s.UpdatedBy).IsOptional();
            modelBuilder.Entity<Ticker>().Ignore(s => s.TickerType);

            modelBuilder.Entity<ExchangeTicker>().HasKey(s => s.Id);
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.UniqueId).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.ExchangeId).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.TickerId).IsOptional();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.BaseTickerId).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.TradeComission).IsOptional();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.MinimumTradableUnit).IsOptional();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.MarketName).IsRequired().HasMaxLength(512);
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.IsActive).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.AddedOn).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.AddedBy).IsRequired();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.UpdatedOn).IsOptional();
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.UpdatedBy).IsOptional();

            modelBuilder.Entity<ExchangeTicker>().Ignore(s => s.Exchange);
            modelBuilder.Entity<ExchangeTicker>().Ignore(s => s.Ticker);
            modelBuilder.Entity<ExchangeTicker>().Ignore(s => s.BaseTicker);

            modelBuilder.Entity<ExchangeTicker>().Property(s => s.ExchangeId).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Exchange_Ticker_BaseTicker", 1) { IsUnique = true }));
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.TickerId).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Exchange_Ticker_BaseTicker", 2) { IsUnique = true }));
            modelBuilder.Entity<ExchangeTicker>().Property(s => s.BaseTickerId).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Exchange_Ticker_BaseTicker", 3) { IsUnique = true }));

            modelBuilder.Entity<ExchangeTicker>().HasRequired(t => t.Ticker).WithMany(p => p.ExchangeTickers).HasForeignKey(f => f.TickerId);
            modelBuilder.Entity<ExchangeTicker>().HasRequired(t => t.BaseTicker).WithMany(p=> p.ExchangeTickers).HasForeignKey(f=>f.BaseTickerId);
            modelBuilder.Entity<ExchangeTicker>().HasRequired(t => t.Exchange).WithMany(p => p.ExchangeTickers).HasForeignKey(f => f.ExchangeId);


            modelBuilder.Entity<MarketSummary>().HasKey(s => s.Id);
            modelBuilder.Entity<MarketSummary>().Property(s => s.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MarketSummary>().Property(s => s.ExchangeTickerId).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.UniqueId).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.TimeStamp).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.CurrentAskPrice).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.CurrentBidPrice).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.CurrentOpenBuyOrders).IsOptional();
            modelBuilder.Entity<MarketSummary>().Property(s => s.CurrentOpenSellOrders).IsOptional();
            modelBuilder.Entity<MarketSummary>().Property(s => s.LastPrice).IsOptional();
            modelBuilder.Entity<MarketSummary>().Property(s => s.RawData).IsOptional();
            modelBuilder.Entity<MarketSummary>().Property(s => s.AddedOn).IsRequired();
            modelBuilder.Entity<MarketSummary>().Property(s => s.AddedBy).IsRequired();
            modelBuilder.Entity<MarketSummary>().Ignore(s => s.ExchangeTicker);

            modelBuilder.Entity<MarketSummary>().HasRequired(t => t.ExchangeTicker);


            base.OnModelCreating(modelBuilder);
        }
    }
}
