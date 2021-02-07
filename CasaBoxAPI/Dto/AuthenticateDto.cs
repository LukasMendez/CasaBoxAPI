using System;
using System.ComponentModel.DataAnnotations;

namespace CasaBoxAPI.Dto
{
    public class AuthenticateDto
    {
        [Required]
        public string Emailadresse { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
