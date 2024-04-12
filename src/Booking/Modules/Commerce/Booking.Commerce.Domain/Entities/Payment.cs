﻿using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Domain.Entities
{
    public class Payment : Entity<Guid>
    {
        public Money Amount { get; set; }

        public DateTime ExecutonTime { get; set; }

        public PaymentStatus Status { get; set; }

        public PaymentMethod Method { get; set; }

        public Guid ProductId { get; set; }

        private Payment() { }

        private Payment(Money amount, DateTime executonTime, PaymentStatus status, PaymentMethod method, Guid productId)
        {
            Amount = amount;
            ExecutonTime = executonTime;
            Status = status;
            Method = method;
            ProductId = productId;
        }

        public static Result<Payment> Create(Money amount, PaymentMethod method, Guid productId)
        {
            return Result.Success(new Payment(amount, DateTime.UtcNow, PaymentStatus.InProgress, method, productId));
        }
    }
}
