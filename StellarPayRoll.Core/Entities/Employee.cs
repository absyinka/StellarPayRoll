using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Entities
{
    public class Employee : BaseEntity
    {
        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DateJoined { get; set; }

        public string Phone { get; set; }

        public string Designation { get; set; }

        public Post Post { get; set; }

        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

        public string Email { get; set; }

        public string NationalIdentificationNo { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public Loan Loan { get; set; }

        public UnionMember UnionMember { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public ICollection<PaymentRecord> PaymentRecords { get; set; } = new HashSet<PaymentRecord>();
    }
}
