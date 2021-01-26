using System;
namespace CasaBoxAPI.Dto
{
    public class CasaBoxVariantDto
    {
        public double M2 { get; set; }

        public double M3 { get; set; }

        public string Type { get; set; }

        public int Pris { get; set; }

        public string Beskrivelse { get; set; } = string.Empty;

        public int AntalLedige { get; set; }
    }
}
