using Microsoft.EntityFrameworkCore;
using StellarPayRoll.Core.Domain.Repositories;
using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Core.Paging;
using StellarPayRoll.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace StellarPayRoll.Domain.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppDBContext context)
        {
            DbContext = context;
        }

        public Task<PaginatedList<RoleDto>> LoadRoleAsync(string filter, int page, int limit) =>
          DbContext.Roles.Where(c => filter == null || c.Name.Contains(filter))
                    .Select(c => new RoleDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Description = c.Description

                    }).AsNoTracking().ToPaginatedListAsync(page, limit);
    }
}
