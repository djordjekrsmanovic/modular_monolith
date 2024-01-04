using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain.Errors;

namespace Booking.UserAccess.Domain.Entities
{
    public class User : Entity<Guid>
    {
        private readonly HashSet<Role> _roles = new();
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public string Email { get; init; }

        public string Password { get; init; }

        public bool isActive { get; init; }

        public IReadOnlyCollection<Role> Roles => _roles.ToList().AsReadOnly();

        public User()
        {

        }

        private User(string firstName, string lastName, string email, string password, bool isActive)
        {
            Id=Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            this.isActive = isActive;
        }

        public static Result<User> CreateFromRegistrationRequest(RegistrationRequest request)
        {
            User user = new User(request.FirstName, request.LastName, request.Email, request.Password, true);
            if (request.Type == Enums.RegistrationType.Host)
            {
                user._roles.Add(Role.Host);
            }
            else if(request.Type==Enums.RegistrationType.Guest)
            {
                user._roles.Add(Role.Guest);
            }
            else
            {
                return Result.Failure<User>(UserErrors.InvalidUserRole);
            }

            return user;
        }
    }
}
