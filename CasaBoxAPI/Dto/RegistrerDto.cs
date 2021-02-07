using System;
using System.ComponentModel.DataAnnotations;

namespace CasaBoxAPI.Dto
{
    public class RegistrerDto
    {
        [Required]
        public string Navn { get; set; }

        [Required]
        public string Emailadresse { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
