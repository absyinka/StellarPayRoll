using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Core.Paging;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<PaginatedList<RoleDto>> LoadRoleAsync(string filter, int page, int limit);
    }
}
