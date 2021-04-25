using System;

namespace StellarPayRoll.Core.Models.Entities
{
    public class BankDetail
    {
        public Guid BankId { get; set; }

        public Bank Bank { get; set; }

        public Guid EmployeeId { get; set; }

        public string BankBranch { get; set; }

        public string AccountNumber { get; set; }
    }
}
