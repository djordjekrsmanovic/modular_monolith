using Booking.BuildingBlocks.Application;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Application
{
    public class GetUserCommandHandler : ICommandHandler<GetUserCommand,Guid>
    {
        

        Task<Result<Guid>> IRequestHandler<GetUserCommand, Result<Guid>>.Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            User user=new User();

            return Task.FromResult(Result<Guid>.Success(user.Id));
        }
    }
}
