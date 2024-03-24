using Booking.UserAccess.Application.Abstractions;

namespace Booking.UserAccess.Application.Implementations
{
    public class CryptograpyProvider : ICryptograpyProvider
    {
        public string HashPassword(string plainTextPassword)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(plainTextPassword);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            string hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
