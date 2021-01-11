using System;
using System.Collections.Generic;

namespace CasaBoxAPI.Models
{
    public class CasaBoxVariant
    {
        public CasaBoxVariant()
        {
        }

        public double M2 { get; set; }

        public double M3 { get; set; }

        public string Type { get; set; }

        public int Pris { get; set; }

        public string Beskrivelse { get; set; }


        // Navigation Property

        public virtual ICollection<CasaBox> CasaBoxes { get; set; }

        public virtual CasaBoxType CasaBoxType { get; set; }
    }

}
