using StellarPayRoll.Core.Models.Datatable;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StellarPayRoll.Core.Domain.Identity;
using StellarPayRoll.Core.Domain.Services;
using StellarPayRoll.Core.Entities;
using StellarPayRoll.Core.Helpers;
using StellarPayRoll.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace StellarPayRoll.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IIdentityService _identityService;
        private readonly UserManager<User> _userManager;

        public RoleController(IRoleService roleService, IIdentityService identityService, UserManager<User> userManager)
        {
            _roleService = roleService;
            _identityService = identityService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleRequestModel model)
        {
            var response = await _roleService.CreateRoleAsync(model);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var userId = Guid.Parse(_identityService.GetUserIdentity());
            var isAdmin = await _userManager.IsInRoleAsync(new User { Id = userId }, Constants.AdminRole);
            var response = await _roleService.GetRoles(isAdmin);
            return Ok(response);
        }

        [HttpGet("data")]
        public async Task<IActionResult> LoadUsers(DatatableRequest datatable)
        {
            var page = datatable.Pagination.Page;
            var limit = datatable.Pagination.PerPage;

            var filter = await datatable.Query.Get("filter", () => Task.FromResult<string?>(null), s => string.IsNullOrWhiteSpace(s) ? null : s.Trim());

            var instances = await _roleService.LoadRolesAsync(filter, page, limit);

            var totalPages = (instances.TotalCount + limit - 1) / limit;
            var list = instances.Rows.ToList();
            var meta = new
            {
                page,
                perpage = limit,
                pages = totalPages,
                total = instances.TotalCount
            };

            return Ok(new
            {
                meta,
                data = list
            });
        }
    }
}
