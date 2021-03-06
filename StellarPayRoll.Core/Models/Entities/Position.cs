using System.Collections.Generic;

namespace StellarPayRoll.Core.Models.Entities
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

    }
}
