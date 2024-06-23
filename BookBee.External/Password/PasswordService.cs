using BookBee.Application.Exceptions;
using BookBee.Application.External.Password;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace BookBee.External.Password
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _options;

        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        public bool Check(string hash, string password)
        {
            string hashed;

            using (SHA256 mySHA256 = SHA256.Create())
            {
                SHA256 sha256 = SHA256.Create();
                ASCIIEncoding encoding = new();
                byte[] stream = null;
                StringBuilder sb = new();
                stream = sha256.ComputeHash(encoding.GetBytes(password));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                hashed = sb.ToString();
            }

            if (hash == hashed)
                return true;
            else
                throw new BadRequestException("Contraseña incorrecta. Intente nuevamente.");
        }

        public string Hash(string password)
        {
            using SHA256 mySHA256 = SHA256.Create();
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new();
            byte[] stream = null;
            StringBuilder sb = new();
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            var hashed = sb.ToString();
            return hashed;
        }
    }
}
