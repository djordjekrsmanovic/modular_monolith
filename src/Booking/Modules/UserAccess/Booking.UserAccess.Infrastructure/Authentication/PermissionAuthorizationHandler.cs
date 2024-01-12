using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Booking.UserAccess.Infrastructure.Authentication
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {

        private readonly IPermissionService _permissionService;

        public PermissionAuthorizationHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            string userId=context.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier)?.Value;

            if (!Guid.TryParse(userId,out Guid parsedUserId))
            {
                return;
            }

            HashSet<string> permissions = await  _permissionService.GetPermissionsAsync(parsedUserId);

            if (permissions.Contains(requirement.Permission))
            {
                context.Succeed(requirement);
            }
            
        }
    }
}
