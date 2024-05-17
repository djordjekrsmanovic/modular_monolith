﻿using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;
using Booking.Commerce.Domain.Events;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscription : Entity<Guid>
    {
        public DateTimeSlot SubscriptionPeriod { get; private set; }

        public SubscriptionStatus Status { get; private set; }

        public SubscriptionPlan Plan { get; private set; }

        public List<SubscriptionPayment> Payments { get; private set; } = new List<SubscriptionPayment>();

        public Guid SubscriberId { get; private set; }


        private Subscription() { }


        private Subscription(DateTimeSlot subscriptionPeriod, SubscriptionPlan plan, Guid subscriberId)
        {
            Id = Guid.NewGuid();
            SubscriptionPeriod = subscriptionPeriod;
            Status = SubscriptionStatus.WaitingForApproval;
            Plan = plan;
            SubscriberId = subscriberId;
        }

        public static Result<Subscription> Create(SubscriptionPlan plan, Guid subscriberId)
        {
            Subscription subscription = new Subscription(DateTimeSlot.Create(DateTime.UtcNow, DateTime.UtcNow.AddMonths(plan.DurationInMonths)).Value, plan, subscriberId);
            return Result.Success(subscription);
        }

        public Result AddPayment(SubscriptionPayment payment)
        {
            if (paymentAlreadyExist(payment))
            {
                return Result.Failure(SubscriptionErrors.SubscriptionPaymentAlreadyExist);
            }
            Payments.Add(payment);
            return Result.Success();
        }

        public bool IsExpired()
        {
            return SubscriptionPeriod.IsDateInSlot(DateTime.UtcNow);
        }

        private bool paymentAlreadyExist(SubscriptionPayment payment)
        {
            return Payments.Any(p => p.Id == payment.Id);
        }

        public Result ConfirmPayment(Guid paymentId)
        {
            SubscriptionPayment payment = Payments.Where(p => p.Id == paymentId).FirstOrDefault();
            if (payment is null)
            {
                return Result.Failure(PaymentErrors.PaymentNotExist);
            }

            var paymentResponse = payment.ConfirmSubscriptionPayment();
            if (paymentResponse.IsSuccess)
            {
                Status = SubscriptionStatus.Active;
                RaiseDomainEvent(new SubscriptionPaymentConfirmedDomainEvent(payment, SubscriptionPeriod.Start, Plan.DurationInMonths, Plan.AccomodationLimit, SubscriberId));
            }

            return paymentResponse;
        }
    }
}
