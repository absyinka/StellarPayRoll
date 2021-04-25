using System;

namespace StellarPayRoll.Core.Models.Entities
{
    public class Image : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public string ImageUrl { get; set; }
    }
}
