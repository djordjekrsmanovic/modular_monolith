﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BuildingBlocks.Domain
{
    public sealed record Error (string Code, string? Description=null)
    {
        
        public static readonly Error None = new(string.Empty, string.Empty);
        public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");


    }

    public class Result
    {

        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            {
                throw new ArgumentException("Invalid error",nameof(error));
            }
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }

        public bool IsFailure => !IsSuccess;

        public Error Error { get;}

        public static  Result Success() => new Result(true,Error.None);


        public static Result Failure(Error error) => new Result(false,error);

        public static Result<TValue> Failure<TValue>(Error error) =>
        new(default, false, error);


        public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);



        public static Result<TValue> Success<TValue>(TValue value) =>
        new(value, true, Error.None);


    }

    public class Result<TValue> : Result 
    {
        private readonly TValue _value;

        protected internal Result(TValue? value,bool isSuccess,Error error):base(isSuccess,error)
        {
            _value = value;
        }

        public TValue Value =>IsSuccess ? _value : throw new InvalidOperationException("The value of a failure result is unaccessible.");

        public static implicit operator Result<TValue>(TValue? value) => Create(value);

        
    }
}
