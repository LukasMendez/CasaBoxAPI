using System;
using CasaBoxAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaBoxAPI
{
    public class CasaBoxContext : DbContext
    {

        public CasaBoxContext(DbContextOptions<CasaBoxContext> options) : base(options) { }

        public DbSet<CasaBox> CasaBoxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CasaBox>(e =>
            {
                e.HasKey(c => c.BoxNummer);
                e.Property(c => c.Ledig)
                    .IsRequired();
                e.Property(c => c.M2)
                    .IsRequired();
                e.Property(c => c.M3)
                    .IsRequired();
                e.Property(c => c.Pris)
                    .IsRequired();
                e.Property(c => c.Type)
                    .HasConversion(
                        type => type.ToString(),
                        type => (CasaBoxType)Enum.Parse(typeof(CasaBoxType), type)
                        )
                    .IsRequired();
            });


            modelBuilder.Entity<Person>(e =>
            {
                e.HasKey(p => p.Mailadresse);
                e.Property(p => p.FuldeNavn)
                    .IsRequired();
                e.Property(p => p.Telefonnummer)
                    .IsRequired();
                e.Property(p => p.Adresse)
                    .IsRequired();
                e.Property(p => p.Postnummer)
                    .IsRequired();
                e.Property(p => p.By)
                    .IsRequired();

            });

            modelBuilder.Entity<Booking>(e =>
            {
                e.HasKey(b => b.BoxNummer);
                e.Property(b => b.Bestillingstidspunkt)
                    .IsRequired();
                e.Property(b => b.BookingId)
                    .IsRequired();
                e.HasOne<CasaBox>(b => b.CasaBox)
                    .WithMany(c => c.Bookinger)
                    .HasForeignKey(b => b.BoxNummer);
                e.HasOne<Person>(b => b.Person)
                    .WithMany(p => p.Bookinger)
                    .HasForeignKey(b => b.Mailadresse)
                    .IsRequired();
                    
            });
        }
    }
}
