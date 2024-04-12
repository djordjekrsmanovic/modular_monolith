using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.UserAccess.Domain.Errors;

namespace Booking.UserAccess.Domain.Entities
{
    public class User : Entity<Guid>
    {
        private readonly HashSet<Role> _roles = new();
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Phone { get; private set; }

        public bool isActive { get; private set; }

        public Address Address { get; private set; }

        public IReadOnlyCollection<Role> Roles => _roles.ToList().AsReadOnly();

        public User()
        {

        }

        private User(string firstName, string lastName, string email, string password, bool isActive, string phone, Address address)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            this.isActive = isActive;
            Phone = phone;
            Address = address;
        }

        public static Result<User> CreateFromRegistrationRequest(RegistrationRequest request)
        {
            User user = new User(request.FirstName, request.LastName, request.Email, request.Password, true, request.Phone, request.Address);

            if (request.Type == Enums.RegistrationType.Host)
            {
                user._roles.Add(Role.Host);
            }
            else if (request.Type == Enums.RegistrationType.Guest)
            {
                user._roles.Add(Role.Guest);
            }
            else
            {
                return Result.Failure<User>(UserErrors.InvalidUserRole);
            }

            return user;
        }

        public Result<Guid> UpdateUser(string firstName, string lastName, string phone, string email, Address address, string currentPassword, string newPassword)
        {
            if (currentPassword != newPassword)
            {
                return Result.Failure<Guid>(UserErrors.WrongPreviousPassword);
            }

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = newPassword;
            Phone = phone;
            Address = Address.Create(address.Street, address.City, address.Country).Value;

            return Result.Success(Id);
        }
    }
}
