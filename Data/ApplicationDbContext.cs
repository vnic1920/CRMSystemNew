using Microsoft.EntityFrameworkCore;
using CRMSystemNew.Models;

namespace CRMSystemNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets - das sind deine Tabellen
        public DbSet<Kunde> Kunden { get; set; } = null!;
        public DbSet<Kontakt> Kontakte { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Kunde-Konfiguration
            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(k => k.Name).IsRequired().HasMaxLength(100);
                entity.Property(k => k.Email).HasMaxLength(100);
                entity.Property(k => k.Telefon).HasMaxLength(20);

                // Beziehung zu Kontakten
                entity.HasMany(k => k.Kontakte)
                      .WithOne(k => k.Kunde)
                      .HasForeignKey(k => k.KundeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Kontakt-Konfiguration
            modelBuilder.Entity<Kontakt>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(k => k.Vorname).IsRequired().HasMaxLength(50);
                entity.Property(k => k.Nachname).IsRequired().HasMaxLength(50);
                entity.Property(k => k.Email).HasMaxLength(100);
                entity.Property(k => k.Telefon).HasMaxLength(20);
            });
        }
    }
}