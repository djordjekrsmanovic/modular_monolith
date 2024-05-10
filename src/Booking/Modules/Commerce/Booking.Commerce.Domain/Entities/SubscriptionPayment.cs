using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;

namespace Booking.Commerce.Domain.Entities
{
    public class SubscriptionPayment : Entity<Guid>
    {
        public Money Amount { get; set; }

        public DateTime ExecutonTime { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod Method { get; set; }


        public Guid SubscriptionId { get; set; }


        private SubscriptionPayment() { }

        private SubscriptionPayment(Money amount, DateTime executonTime, PaymentStatus status, PaymentMethod method, Guid productId)
        {
            Amount = amount;
            ExecutonTime = executonTime;
            Status = status;
            Method = method;
            SubscriptionId = productId;
        }

        public static Result<SubscriptionPayment> Create(Money amount, PaymentMethod method, Guid productId)
        {
            return Result.Success(new SubscriptionPayment(amount, DateTime.UtcNow, PaymentStatus.InProgress, method, productId));
        }

        public Result ConfirmSubscriptionPayment()
        {
            if (Status == PaymentStatus.InProgress)
            {
                Status = PaymentStatus.Confirmed;
                //throw domain event to trigger integration event to increase number of allowed accommodations to post
                return Result.Success();
            }
            else
            {
                return Result.Failure(PaymentErrors.InvalidPaymentState);
            }
        }


    }
}
