using System;
using System.Collections;
using System.Collections.Generic;

namespace CasaBoxAPI.Models
{
    public class CasaBox
    {
        public CasaBox()
        {
        }

        public int BoxNummer { get; set; }

        public bool Ledig { get; set; }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public string Type { get; set; }

        public string Note { get; set; }

        // Navigation Property

        public virtual CasaBoxVariant CasaBoxVariant { get; set; }

        public virtual ICollection<Booking> Bookinger { get; set; }

        public virtual ICollection<BookingHistorik> BookingHistorik { get; set; }

    }


}
