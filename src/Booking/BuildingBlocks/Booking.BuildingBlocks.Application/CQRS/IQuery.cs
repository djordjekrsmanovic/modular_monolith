using Booking.BuildingBlocks.Domain;
using MediatR;

namespace Booking.BuildingBlocks.Application.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
