using StellarPayRoll.Core.Models.Enums;
using System;
using System.Collections.Generic;

namespace StellarPayRoll.Core.Models.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateJoined { get; set; }

        public Guid DesignationId { get; set; }

        public Designation Designation { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public string NationalIdentificationNo { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public UnionMember UnionMember { get; set; }

        public Image Image { get; set; }

        public AddressDetail AddressDetail { get; set; }

        public BankDetail BankDetail { get; set; }

        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new HashSet<PaymentRecord>();
    }
}
