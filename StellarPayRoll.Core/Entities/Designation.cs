using System;
using System.Collections.Generic;
using System.Text;

namespace StellarPayRoll.Core.Entities
{
    public class Designation : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Designation> Designations { get; set; } = new HashSet<Designation>();

        public ICollection<Department> Departments { get; set; } = new HashSet<Department>();

        public ICollection<Post> DepartmentDesignations { get; set; } = new HashSet<Post>();

    }
}
