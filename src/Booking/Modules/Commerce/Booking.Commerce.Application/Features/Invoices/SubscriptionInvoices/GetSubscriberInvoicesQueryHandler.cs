using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Invoices.SubscriptionInvoices
{
    internal class GetSubscriberInvoicesQueryHandler : IQueryHandler<GetSubscriberInvoicesQuery, List<SubscriptionInvoiceResponse>>
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public GetSubscriberInvoicesQueryHandler(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<Result<List<SubscriptionInvoiceResponse>>> Handle(GetSubscriberInvoicesQuery request, CancellationToken cancellationToken)
        {
            Subscriber subscriber = await _subscriberRepository.GetAsync(request.SubscriberId);

            var response = subscriber.Invoices.Select(x =>
            {
                return new SubscriptionInvoiceResponse(
                    InvoiceId: x.Id,
                    SubscriptionId: x.Payment.SubscriptionId,

                    Price: x.Payment.Amount.ConvertToString(),
                    Method: x.Payment.Method,
                    CreatedAt: x.CreatedAt
               );
            }).ToList();

            return response;
        }
    }
}
