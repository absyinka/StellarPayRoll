using System;

namespace StellarPayRoll.Core.Models.Entities
{
    public class AddressDetail
    {
        public Guid StateId { get; set; }

        public State State { get; set; }

        public Guid EmployeeId { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }
    }
}
