using Conway.InterimPods.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Conway.InterimPods.Infrastructure.Data
{
    public class PodScansDbContext : DbContext
    {
        public PodScansDbContext(DbContextOptions<PodScansDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PodScan>(entity =>
            {
                entity
                    .ToTable("POD_SCANNING", "LIVE")
                    .HasKey(m => m.Id);


                entity.Property(m => m.Id).HasColumnName("PS_ID");
                entity.Property(m => m.DateProcessed).HasColumnName("PS_DATE_PROCESSED");
                entity.Property(m => m.SharePointUrl).HasColumnName("PS_URL");
                entity.Property(m => m.OrderId).HasColumnName("PS_ORDER_ID");
                entity.Property(m => m.TicketId).HasColumnName("PS_TICKET_ID");
                entity.Property(m => m.LoadedAt).HasColumnName("PS_LOADED_AT");
                entity.Property(m => m.LoadedAtConfidence).HasColumnName("PS_LOADED_AT_CONFIDENCE");
                entity.Property(m => m.FileName).HasColumnName("PS_FILE_NAME");
                entity.Property(m => m.Message).HasColumnName("PS_MESSAGE");
                entity.Property(m => m.TimeOnSite).HasColumnName("PS_TIME_ON_SITE");
                entity.Property(m => m.TimeOnSiteConfidence).HasColumnName("PS_TIME_ON_SITE_CONFIDENCE");
                entity.Property(m => m.StartOffload).HasColumnName("PS_START_OFFLOAD");
                entity.Property(m => m.StartOffloadConfidence).HasColumnName("PS_START_OFFLOAD_CONFIDENCE");
                entity.Property(m => m.TimeOffSite).HasColumnName("PS_TIME_OFF_SITE");
                entity.Property(m => m.TimeOffSiteConfidence).HasColumnName("PS_TIME_OFF_SITE_CONFIDENCE");
                entity.Property(m => m.ScannedDocument).HasColumnName("PS_SCANNED_DOCUMENT").HasColumnType("BLOB");
                entity.Property(m => m.Status).HasColumnName("PS_STATUS");
                entity.Property(m => m.ScanStatus).HasColumnName("PS_SCAN_STATUS");
                entity.Property(m => m.ConsignmentNote).HasColumnName("PS_CONSIGNMENT_NOTE");
                entity.Property(m => m.RevenueCenter).HasColumnName("PS_REVENUE_CENTER");
                entity.Property(m => m.ConsignmentNoteConfidence).HasColumnName("PS_CONSIGNMENT_NOTE_CONFIDENCE");
                entity.Property(m => m.TicketDate).HasColumnName("PS_TICKET_DATE");
                entity.Property(m => m.TicketDateConfidence).HasColumnName("PS_TICKET_DATE_CONFIDENCE");
                entity.Property(m => m.WeighConReference).HasColumnName("PS_WEIGHCON_REF");
                entity.Property(m => m.WeighConRefConfidence).HasColumnName("PS_WEIGHCON_REF_CONFIDENCE");
                entity.Property(m => m.ShortOrderNo).HasColumnName("PS_SHORT_ORDER_REF");

            });
        }

        public required DbSet<PodScan> PodScans { get; set; }
    }
}
