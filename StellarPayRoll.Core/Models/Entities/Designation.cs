using System.Collections.Generic;

namespace StellarPayRoll.Core.Models.Entities
{
    public class Designation : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
