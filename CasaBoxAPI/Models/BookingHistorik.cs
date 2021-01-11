using System;
namespace CasaBoxAPI.Models
{
    public class BookingHistorik
    {
        public BookingHistorik()
        {
        }

        public string BookingId { get; set; }

        public string Mailadresse { get; set; }

        public DateTime Bestillingstidspunkt { get; set; }

        public int BoxNummer { get; set; }

        // Navigation Property

        public virtual CasaBox CasaBox { get; set; }

    }
}
