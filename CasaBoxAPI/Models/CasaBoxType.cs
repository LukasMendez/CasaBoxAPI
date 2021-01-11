using System;
using System.Collections.Generic;

namespace CasaBoxAPI.Models
{
    public class CasaBoxType
    {
        public CasaBoxType()
        {
        }

        public string Type { get; set; }

        public virtual ICollection<CasaBoxVariant> CasaBoxVarianter { get; set; }
    }
}
