using Booking.BuildingBlocks.Application.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Application
{
    public record GetUserCommand(Guid userId) : ICommand<Guid>;
    
}
