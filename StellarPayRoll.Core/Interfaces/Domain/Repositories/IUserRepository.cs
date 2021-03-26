using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserAsync(string email);

        //Task<PaginatedList<UserDto>> LoadUsersAsync(string filter, int page, int limit);

    }
}
