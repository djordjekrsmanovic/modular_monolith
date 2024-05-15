using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Events;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Reservations.ConfirmPayment
{
    public class ReservationPaymentConfirmedDomainEventHandler : IDomainEventHandler<ReservationPaymentConfirmedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IReservationInvoiceRepository _reservationInvoiceRepository;

        private readonly IPayerRepository _payerRepository;

        public ReservationPaymentConfirmedDomainEventHandler(IUnitOfWork unitOfWork, IReservationInvoiceRepository reservationInvoiceRepository, IPayerRepository payerRepository)
        {
            _unitOfWork = unitOfWork;
            _reservationInvoiceRepository = reservationInvoiceRepository;
            _payerRepository = payerRepository;
        }

        public async Task Handle(ReservationPaymentConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            ReservationInvoice invoice = ReservationInvoice.Create(notification.payment).Value;

            Payer payer = await _payerRepository.GetAsync(notification.payment.PayerId);

            payer.AddInvoice(invoice);

            await _reservationInvoiceRepository.Add(invoice);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
