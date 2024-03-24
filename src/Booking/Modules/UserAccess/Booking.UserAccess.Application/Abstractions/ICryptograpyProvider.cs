namespace Booking.UserAccess.Application.Abstractions
{
    public interface ICryptograpyProvider
    {
        public string HashPassword(string plainTextPassword);
    }
}
