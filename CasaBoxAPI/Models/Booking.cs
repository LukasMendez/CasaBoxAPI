using System;
using System.Linq;
using System.Text;

namespace CasaBoxAPI.Models
{
    public class Booking
    {
        public Booking(
            int boxNummer,
            string mailadresse)
        {
            BoxNummer = boxNummer;
            Mailadresse = mailadresse;
            Bestillingstidspunkt = DateTime.Now;
            BookingId = GenerateRandomId();
        }

        // PK/FK
        public int BoxNummer { get; set; }

        // FK 
        public string Mailadresse { get; set; }

        // Non-key attributes

        public DateTime Bestillingstidspunkt { get; set; }

        public string BookingId { get; set; }

        // Navigation Properties

        public virtual CasaBox CasaBox { get; set; }

        public virtual Person Person { get; set; }

        private string GenerateRandomId()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            
            return builder.ToString();
        }

    }
}
