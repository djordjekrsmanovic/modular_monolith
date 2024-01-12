using Booking.BuildingBlocks.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BuildingBlocks.Application.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
