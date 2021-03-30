using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StellarPayRoll.API.Filters;
using StellarPayRoll.Core.Domain.Identity;
using StellarPayRoll.Core.Domain.Services;
using StellarPayRoll.Core.Entities;
using StellarPayRoll.Core.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace StellarPayRoll.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly IIdentityService _identityService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userService, UserManager<User> userManager, IIdentityService identityService, IConfiguration configuration, ILogger<AccountController> logger)
        {
            _userService = userService;

            _userManager = userManager;

            _identityService = identityService;

            _configuration = configuration;

            _logger = logger;
        }

        [Authorize(Roles = "Admin,Manager")]
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterUserRequestModel model)
        {
            var response = await _userService.CreateUserAsync(model);

            return Ok(response);
        }

        [HttpPost("token")]
        //[ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponseModel))]
        //[ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ValidationResultModel))]
        public async Task<IActionResult> Token([FromBody] LoginRequestModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var isValidPassword = await _userManager.CheckPasswordAsync(user, $"{model.Password}{user.HashSalt}");

                if (isValidPassword)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var token = _identityService.GenerateToken(user, roles);
                    var tokenResponse = new LoginResponseModel
                    {
                        Message = "Login Successful",
                        Status = true,
                        Data = new LoginResponseData
                        {
                            Roles = roles,
                            Email = user.Email
                        }
                    };
                    var expiry = DateTimeOffset.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetValue<string>("JwtTokenSettings:TokenExpiryPeriod")));
                    Response.Headers.Add("Token", token);
                    Response.Headers.Add("TokenExpiry", expiry.ToUnixTimeMilliseconds().ToString());
                    Response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
                    return Ok(tokenResponse);
                }

            }
            var response = new BaseResponse
            {
                Message = "Invalid Credential",
                Status = false
            };
            return BadRequest(response);
        }

    }

}

