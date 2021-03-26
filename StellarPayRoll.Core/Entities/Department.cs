using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
