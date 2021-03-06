using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StellarPayRoll.Core.Models.Entities
{
    public class PaymentRecord : BaseEntity
    {
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public DateTime PayDate { get; set; }

        public string PayMonth { get; set; }

        public Guid TaxYearId { get; set; }

        public TaxYear TaxYear { get; set; }

        public string TaxCode { get; set; }

        [Column(TypeName = "money")] 
        public decimal HourlyRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal HoursWorked { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractualHours { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OvertimeHours { get; set; }

        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal CompulsorySavings { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }

        [Column(TypeName = "money")]
        public decimal? SLC { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }

        [Column(TypeName = "money")]
        public decimal NetPayment { get; set; }
    }
}
