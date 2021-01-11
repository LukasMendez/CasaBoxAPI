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
            modelBuilder.Entity<CasaBoxType>(e =>
            {
                e.HasKey(ct => ct.Type);
            });

            modelBuilder.Entity<CasaBoxVariant>(e =>
            {
                e.HasKey(cv => new { cv.M2, cv.M3, cv.Type });
                e.Property(cv => cv.Pris)
                    .IsRequired();
                e.HasOne<CasaBoxType>(cv => cv.CasaBoxType)
                    .WithMany(ct => ct.CasaBoxVarianter)
                    .HasForeignKey(cv => cv.Type);
                 
            });



            modelBuilder.Entity<CasaBox>(e =>
            {
                e.HasKey(c => c.BoxNummer);
                e.Property(c => c.BoxNummer)
                    .ValueGeneratedNever();
                e.Property(c => c.Ledig)
                    .IsRequired();
                e.HasOne<CasaBoxVariant>(c => c.CasaBoxVariant)
                    .WithMany(cv => cv.CasaBoxes)
                    .HasForeignKey(c => new { c.M2, c.M3, c.Type })
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

            modelBuilder.Entity<BookingHistorik>(e =>
            {
                e.HasKey(bh => bh.BookingId);
                e.Property(bh => bh.Mailadresse)
                    .IsRequired();
                e.Property(bh => bh.Bestillingstidspunkt)
                    .IsRequired();
                e.HasOne<CasaBox>(bh => bh.CasaBox)
                    .WithMany(c => c.BookingHistorik)
                    .HasForeignKey(bh => bh.BoxNummer)
                    .IsRequired();
            });
        }
    }
}
