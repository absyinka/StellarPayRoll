using Microsoft.EntityFrameworkCore;
using StellarPayRoll.Core.Domain.Identity;
using StellarPayRoll.Core.Domain.Repositories;
using StellarPayRoll.Core.Domain.Services;
using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Exceptions;
using StellarPayRoll.Core.Models.Dtos.ResponseModels;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Core.Paging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StellarPayRoll.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IIdentityService _identityService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IIdentityService identityService, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _identityService = identityService;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> CreateUserAsync(RegisterUserRequestModel model)
        {
            var emailExists = await _userRepository.ExistsAsync(u => u.Email == model.Email);

            if(emailExists)
            {
                throw new BadRequestException($"User with '{model.Email}' already exists!");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                HashSalt = Guid.NewGuid().ToString(),
            };

            user.PasswordHash = _identityService.GetPasswordHash(model.Password, user.HashSalt);

            var roles = await _roleRepository.GetAsync(model.Roles);

            foreach (var role in roles)
            {
                var userRole = new UserRole
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    UserId = user.Id,
                    Role = role,
                    RoleId = role.Id
                };
                user.UserRoles.Add(userRole);
            }

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new BaseResponse
            {
                Status = true,
                Message = $"User successfully created"
            };

        }

        public async Task<UserResponseModel> GetUserAsync(string email)
        {
            var user = await _userRepository.Query()
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new NotFoundException("User not found!");
            }

            var result = new UserResponseModel
            {
                Status = true,
                Message = "Successful",
                Data = new UserDto
                {
                    Email = user.Email,
                    Id = user.Id,
                    Roles = user.UserRoles.Select(r => new RoleDto
                    {
                        Id = r.RoleId,
                        Description = r.Role.Description,
                        Name = r.Role.Name
                    })
                }
            };

            return result;
        }

        public Task<PaginatedList<UserDto>> LoadUsersAsync(string filter, int page, int limit) =>
            _userRepository.LoadUsersAsync(filter, page, limit);
    }
}
