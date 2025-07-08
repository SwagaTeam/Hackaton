using Application.Services.Abstractions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Application.Services.Implementations
{
    public class Encrypt : IEncrypt
    {
        public string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                System.Text.Encoding.ASCII.GetBytes(salt),
                KeyDerivationPrf.HMACSHA512,
                500,
                64));
        }
    }
}
