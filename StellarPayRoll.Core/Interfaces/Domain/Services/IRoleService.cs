using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Models.Dtos.ResponseModels;
using StellarPayRoll.Core.Paging;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Services
{
    public interface IRoleService
    {
        public Task<BaseResponse> CreateRoleAsync(CreateRoleRequestModel model);

        Task<RolesResponseModel> GetRoles();

        Task<RolesResponseModel> GetRoles(bool isAdmin);

        Task<PaginatedList<RoleDto>> LoadRolesAsync(string filter, int page, int limit);
    }
}
