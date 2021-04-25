using Microsoft.EntityFrameworkCore;
using StellarPayRoll.Core.Domain.Repositories;
using StellarPayRoll.Core.Domain.Services;
using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Exceptions;
using StellarPayRoll.Core.Helpers;
using StellarPayRoll.Core.Models.Dtos.ResponseModels;
using StellarPayRoll.Core.Models.Entities;
using StellarPayRoll.Core.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StellarPayRoll.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<BaseResponse> CreateRoleAsync(CreateRoleRequestModel model)
        {
            var roleExists = await _roleRepository.ExistsAsync(u => u.Name == model.Name);

            if (roleExists)
            {
                throw new BadRequestException($"Role with name '{model.Name}' already exists.");
            }

            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description
            };

            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync();

            return new BaseResponse
            {
                Status = true,
                Message = "Role created successfully"
            };
        }

        public async Task<RolesResponseModel> GetRoles()
        {
            var roles = await _roleRepository.Query().Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description

            }).ToListAsync();

            return new RolesResponseModel
            {
                Data = roles,
                Status = true,
                Message = "Successful"
            };
        }

        public async Task<RolesResponseModel> GetRoles(bool isAdmin)
        {
            IEnumerable<RoleDto> roles = await _roleRepository.Query().Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description

            }).ToListAsync();

            if (!isAdmin)
            {
                roles = roles.Where(r => r.Name != Constants.AdminRole);
            }

            return new RolesResponseModel
            {
                Data = roles,
                Status = true,
                Message = "Successful"
            };
        }

        public Task<PaginatedList<RoleDto>> LoadRolesAsync(string filter, int page, int limit) =>
            _roleRepository.LoadRoleAsync(filter, page, limit);
    }
}
