using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;
using Mupsee.Models.User;

namespace Mupsee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public UserResponse Login([FromBody] UserLoginViewModel userLoginVm)
        {
            var userVm = _userService.Authenticate(userLoginVm);

            if (userVm != null)
            {
                var token = _userService.GenerateToken(userVm);
                return new UserResponse { 
                    Token = token,
                };
            }

            return null;
        }
    }
}

