using StellarPayRoll.Core.Models;
using System.Threading.Tasks;

namespace StellarPayRoll.Core.Domain.Services
{
    public interface IUserService
    {
        public Task<BaseResponse> CreateUserAsync(RegisterUserRequestModel model);

        Task<UserResponseModel> GetUserAsync(string email);

        //Task<PaginatedList<UserDto>> LoadUsersAsync(string filter, int page, int limit);
    }
}
