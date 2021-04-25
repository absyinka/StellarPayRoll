using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Dtos
{
    public class PaymentRecordDto
    {
        public Guid Id { get; set; }

        public DateTime PayDate { get; set; }

        public string PayMonth { get; set; }

        public string TaxCode { get; set; }

        public decimal TotalEarnings { get; set; }

        public decimal TotalDeduction { get; set; }

        public decimal NetPayment { get; set; }

        public ICollection<EmployeeDto> Departments { get; set; } = new List<EmployeeDto>();

    }
}
