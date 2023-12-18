using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain
{
    public class RegistrationStatus : ValueObject
    {

        private RegistrationStatus(string value) {
            Value = value;
        }

        public string Value{get;}
        
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static RegistrationStatus Confirmed =>  new RegistrationStatus(nameof(Confirmed));
        
        public static RegistrationStatus Rejected => new RegistrationStatus(nameof(Rejected));

        public static RegistrationStatus Expired => new RegistrationStatus(nameof(Expired));
    }
}
