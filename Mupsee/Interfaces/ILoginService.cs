using Mupsee.Models.User;

namespace Mupsee.Interfaces
{
    /// <summary>
    /// ILoginService
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Method for generating token
        /// </summary>
        /// <param name="userVm"></param>
        /// <returns></returns>
        string GenerateToken(UserModelViewModel userVm);
        /// <summary>
        /// Method for authenticating user
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        UserModelViewModel Authenticate(UserLoginViewModel userLoginVm);
    }
}
