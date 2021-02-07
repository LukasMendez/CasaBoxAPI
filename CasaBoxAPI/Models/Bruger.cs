﻿using System;
namespace CasaBoxAPI.Models
{
    public class Bruger
    {

        public int Id { get; set; }

        public string Navn { get; set; }

        public string Emailadresse { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

    }
}
