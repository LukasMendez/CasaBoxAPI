using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace CasaBoxAPI.Models
{
    public class Person
    {
        public Person(
            string mailadresse,
            string fuldeNavn,
            string telefonnummer,
            string adresse,
            string postnummer,
            string by)
        {
            Mailadresse = mailadresse;
            FuldeNavn = fuldeNavn;
            Telefonnummer = telefonnummer;
            Adresse = adresse;
            Postnummer = postnummer;
            By = by;
        }

        public string Mailadresse { get; set; }

        public string FuldeNavn { get; set; }

        public string Telefonnummer { get; set; }

        public string Adresse { get; set; }

        public string Postnummer { get; set; }

        public string By { get; set; }

        // Navigation Propertyy

        public virtual ICollection<Booking> Bookinger { get; set; }

    }
}
