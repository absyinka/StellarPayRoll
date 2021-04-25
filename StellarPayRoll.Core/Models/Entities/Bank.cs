using System.Collections.Generic;

namespace StellarPayRoll.Core.Models.Entities
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<BankDetail> BankDetails { get; set; } = new HashSet<BankDetail>();
    }
}
