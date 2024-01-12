using Microsoft.AspNetCore.Authorization;

namespace Booking.BuildingBlocks.Presentation
{
    public class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(Domain.Enums.Permission permission)
            : base(policy: permission.ToString())
        {
        }
    }
}
