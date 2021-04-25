using StellarPayRoll.Core.Models.Enums;
using System;

namespace StellarPayRoll.Core.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }

        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public DateTime DateJoined { get; set; }

        public string Phone { get; set; }

        public string Designation { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public string NationalIdentificationNo { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public UnionMember UnionMember { get; set; }

        public string ImageUrl { get; set; }

    }
}
