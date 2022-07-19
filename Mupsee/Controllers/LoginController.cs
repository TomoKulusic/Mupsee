using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models.User;

namespace Mupsee.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public string Login([FromBody] UserLoginViewModel userLoginVm)
        {
            var userVm = _loginService.Authenticate(userLoginVm);

            if (userVm != null)
            {
                var token = _loginService.GenerateToken(userVm);
                return token;
            }

            return null;
        }


    }
}

