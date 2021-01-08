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

        public int M2 { get; set; }

        public int M3 { get; set; }

        public int Pris { get; set; }

        public CasaBoxType Type { get; set; }

        public string Beskrivelse { get; set; }

        // Navigation Property

        public virtual ICollection<Booking> Bookinger { get; set; }

    }

    public enum CasaBoxType
    {
        Garage,
        Depotrum
    }
}
