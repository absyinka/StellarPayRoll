using StellarPayRoll.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Services
{
    public interface IRoleService
    {
        public Task<BaseResponse> CreateRoleAsync(CreateRoleRequestModel model);

        Task<RolesResponseModel> GetRoles();
    }
}
