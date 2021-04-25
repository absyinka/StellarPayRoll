using System.Collections.Generic;

namespace StellarPayRoll.Core.Models.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string HashSalt { get; set; }

        public bool IsEmailVerified { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
