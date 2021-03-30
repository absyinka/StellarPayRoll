using StellarPayRoll.Core.Models.Datatable;
using Microsoft.AspNetCore.Mvc;
using StellarPayRoll.Core.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace StellarPayRoll.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser([FromRoute] string email)
        {
            var response = await _userService.GetUserAsync(email);
            return Ok(response);
        }

       
        [HttpGet("data")]
        public async Task<IActionResult> LoadUsers(DatatableRequest datatable)
        {
            var page = datatable.Pagination.Page;

            var limit = datatable.Pagination.PerPage;

            var filter = await datatable.Query.Get("filter", () => Task.FromResult<string?>(null),
                                                   s => string.IsNullOrWhiteSpace(s) ? null : s.Trim());

            var instances = await _userService.LoadUsersAsync(filter, page, limit);

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
