using Booking.BuildingBlocks.Domain;
using MediatR;

namespace Booking.BuildingBlocks.Application.CQRS
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
    {
    }
}
