using System;
using System.Collections.Generic;

namespace StellarPayRoll.Core.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<RoleDto> Roles { get; set; } = new List<RoleDto>();
    }
}
