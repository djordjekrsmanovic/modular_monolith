using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Invoices.ReservationInvoices
{
    public class GetPayerReservationInvoicesQueryHandler : IQueryHandler<GetPayerReservationInvoicesQuery, List<ReservationInvoiceResponse>>
    {
        public IPayerRepository _payerRepository;

        public GetPayerReservationInvoicesQueryHandler(IPayerRepository payerRepository)
        {
            _payerRepository = payerRepository;
        }

        public async Task<Result<List<ReservationInvoiceResponse>>> Handle(GetPayerReservationInvoicesQuery request, CancellationToken cancellationToken)
        {
            Payer payer = await _payerRepository.GetAsync(request.PayerId);

            var response = payer.Invoices.Select(x =>
            {
                return new ReservationInvoiceResponse(
                    InvoiceId: x.Id,
                    ReservationId: x.Payment.ReservationId,
                    Price: x.Payment.Amount.ConvertToString(),
                    Method: x.Payment.Method,
                    CreatedAt: x.CreatedAt
               );
            }).ToList();

            return response;
        }
    }
}
