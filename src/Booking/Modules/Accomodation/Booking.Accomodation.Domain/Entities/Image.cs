using Booking.AccommodationNS.Domain.Errors;
using Booking.BuildingBlocks.Domain;
using System.Security.Cryptography;
using System.Text;

namespace Booking.AccommodationNS.Domain.Entities
{
    public class Image : Entity<Guid>
    {
        public string Name { get; private set; }

        public Byte[] Content { get; private set; }

        public string Extension { get; private set; }

        public Guid AccomodationId { get; private set; }

        public string Hash { get; private set; }

        private Image() { }

        private Image(string name, byte[] content, string extension, Guid accomodationId, string hash)
        {
            Id = Guid.NewGuid();
            Name = name;
            Content = content;
            Extension = extension;
            AccomodationId = accomodationId;
            Hash = hash;
        }

        public static Result<Image> Create(string name, string extension, string content, Guid accommodationId, string recievedHash)
        {

            if (!isImageValid(content, recievedHash))
            {
                return Result.Failure<Image>(AccommodationErrors.ImageIsCorrupted);
            }

            return new Image(name, Convert.FromBase64String(content.Split(",")[1]), extension, accommodationId, recievedHash);

        }

        public void AddImageToAccommodation(Guid accommodationId)
        {
            AccomodationId = accommodationId;
        }


        private static bool isImageValid(string base64ImageData, string receivedHash)
        {
            string content = base64ImageData.Split(",")[1];
            byte[] imageData = Encoding.UTF8.GetBytes(content);

            string calculatedHash = CalculateHash(imageData);

            return calculatedHash.Equals(receivedHash);
        }

        private static string CalculateHash(byte[] imageData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(imageData);
                StringBuilder hexString = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    hexString.Append(b.ToString("x2"));
                }

                return hexString.ToString();
            }
        }

        public string ToBase64()
        {
            string base64 = Convert.ToBase64String(Content);
            return $"data:image/{Extension};charset=utf-8;base64,{base64}";
        }




    }
}
