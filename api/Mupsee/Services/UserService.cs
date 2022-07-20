using Microsoft.IdentityModel.Tokens;
using Mupsee.Interfaces;
using Mupsee.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mupsee.Services
{
    public class UserService : IUserService
    {
        private IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _config = config;
        }

        /// <inheritdoc/>
        public string GenerateToken(UserModelViewModel userVm)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userVm.Email),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <inheritdoc/>
        public UserModelViewModel Authenticate(UserLoginViewModel userLoginVm)
        {
            try
            {
                var currentUser = DummyUsers.Users.FirstOrDefault(o => o.Username.ToLower() == userLoginVm.Username.ToLower() && o.Password == userLoginVm.Password);

                if (currentUser is not null)
                    return currentUser;
                
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
