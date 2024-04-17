using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscription : Entity<Guid>
    {
        public DateTimeSlot SubscriptionPeriod { get; set; }

        public SubscriptionStatus Status { get; set; }

        public SubscriptionPlan Plan { get; set; }

        public List<Payment> Payments { get; set; } = new List<Payment>();

        public bool IsExpired()
        {
            return SubscriptionPeriod.isInRange(DateTime.UtcNow);
        }
        private Subscription() { }


        private Subscription(DateTimeSlot subscriptionPeriod, SubscriptionPlan plan)
        {
            Id = Guid.NewGuid();
            SubscriptionPeriod = subscriptionPeriod;
            Status = SubscriptionStatus.Active;
            Plan = plan;
        }

        public static Result<Subscription> Create(SubscriptionPlan plan)
        {
            Subscription subscription = new Subscription(DateTimeSlot.Create(DateTime.UtcNow, DateTime.UtcNow.AddMonths(plan.durationInMonths)).Value, plan);
            return Result.Success(subscription);
        }

        public Result AddPayment(Payment payment)
        {
            if (paymentAlreadyExist(payment))
            {
                return Result.Failure(SubscriptionErrors.SubscriptionPaymentAlreadyExist);
            }
            Payments.Add(payment);
            return Result.Success();
        }

        private bool paymentAlreadyExist(Payment payment)
        {
            return Payments.Any(p => p.Id == payment.Id);
        }

        public Result ConfirmPayment(Guid paymentId)
        {
            Payment payment = Payments.Where(p => p.Id == paymentId).FirstOrDefault();
            if (payment is null)
            {
                return Result.Failure(PaymentErrors.PaymentNotExist);
            }

            return payment.ConfirmPayment();
        }
    }
}
