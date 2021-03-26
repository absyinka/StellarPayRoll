using StellarPayRoll.Core.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Models
{
    public class CreateRoleRequestModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class RolesResponseModel : BaseResponse
    {
        public IEnumerable<RoleDto> Data { get; set; } = new List<RoleDto>();
    }
}
