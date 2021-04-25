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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(AppDBContext context)
        {
            DbContext = context;
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await Query().SingleOrDefaultAsync(u => u.Email == email);
        }

        public Task<PaginatedList<UserDto>> LoadUsersAsync(string filter, int page, int limit) =>
          DbContext.Users.Where(c => filter == null || c.Email.Contains(filter))
                    .Select(c => new UserDto
                    {
                        Id = c.Id,
                        Email = c.Email

                    }).AsNoTracking().ToPaginatedListAsync(page, limit);
    }
}
