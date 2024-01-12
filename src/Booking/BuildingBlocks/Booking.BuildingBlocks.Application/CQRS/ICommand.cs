using Booking.BuildingBlocks.Domain;
using MediatR;

namespace Booking.BuildingBlocks.Application.CQRS
{
    public interface ICommand : IRequest<Result>
    {

    }

    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }

}
