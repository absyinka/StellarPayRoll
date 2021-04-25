using StellarPayRoll.Core.Attributes;
using StellarPayRoll.Core.Dtos;
using StellarPayRoll.Core.Paging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Models.Dtos.ResponseModels
{
    public class RegisterUserRequestModel
    {   
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [EnumerableRequired]
        public IList<Guid> Roles { get; set; } = new List<Guid>();

    }

    public class LoginRequestModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginResponseModel : BaseResponse
    {
        public LoginResponseData Data { get; set; }
    }

    public class UserResponseModel : BaseResponse
    {
        public UserDto Data { get; set; }
    }

    public class UsersResponseModel : BaseResponse
    {
        public PagedResult<UserDto> Data { get; set; }
    }

    public class LoginResponseData
    {
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; } = new List<string>();

    }
}
