using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaBoxAPI.Helpers;
using CasaBoxAPI.Helpers.Exceptions;
using CasaBoxAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CasaBoxAPI.Services
{
    public interface IUserService
    {
        Bruger Authenticate(string email, string password);
        IEnumerable<Bruger> GetAll();
        Bruger GetById(int id);
        Bruger Create(Bruger bruger, string password);
        void Update(Bruger bruger, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private CasaBoxContext _context;

        public UserService(CasaBoxContext context)
        {
            _context = context;
        }

        public Bruger Authenticate(string emailAdresse, string password)
        {
            if (string.IsNullOrEmpty(emailAdresse) || string.IsNullOrEmpty(password))
                return null;

            var bruger = _context.Brugere.SingleOrDefault(x => x.Emailadresse == emailAdresse);

            // check if username exists
            if (bruger == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, bruger.PasswordHash, bruger.PasswordSalt))
                return null;

            // authentication successful
            return bruger;
        }

        public IEnumerable<Bruger> GetAll()
        {
            return _context.Brugere;
        }

        public Bruger GetById(int id)
        {
            return _context.Brugere.Find(id);
        }

        public Bruger Create(Bruger bruger, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password er påkrævet!");

            if (_context.Brugere.Any(x => x.Emailadresse == bruger.Emailadresse))
                throw new AppException("Emailadresse \"" + bruger.Emailadresse + "\" er allerede i brug");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            bruger.PasswordHash = passwordHash;
            bruger.PasswordSalt = passwordSalt;

            _context.Brugere.Add(bruger);
            _context.SaveChanges();

            return bruger;
        }

        public void Update(Bruger brugerParam, string password = null)
        {
            var bruger = _context.Brugere.Find(brugerParam.Id);

            if (bruger == null)
                throw new AppException("Brugeren blev ikke fundet");

            // update email if it has changed
            if (!string.IsNullOrWhiteSpace(brugerParam.Emailadresse) && brugerParam.Emailadresse != bruger.Emailadresse)
            {
                // throw error if the new username is already taken
                if (_context.Brugere.Any(x => x.Emailadresse == brugerParam.Emailadresse))
                    throw new AppException("Emailadressen " + brugerParam.Emailadresse + " er allerede i brug");

                bruger.Emailadresse = brugerParam.Emailadresse;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(brugerParam.Navn))
                bruger.Navn = brugerParam.Navn;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                bruger.PasswordHash = passwordHash;
                bruger.PasswordSalt = passwordSalt;
            }

            _context.Brugere.Update(bruger);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Brugere.Find(id);
            if (user != null)
            {
                _context.Brugere.Remove(user);
                _context.SaveChanges();
            }
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
