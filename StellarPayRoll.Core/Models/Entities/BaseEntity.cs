using System;

namespace StellarPayRoll.Core.Models.Entities
{
    public abstract class BaseEntity : ISoftDelete, IAuditBase
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
