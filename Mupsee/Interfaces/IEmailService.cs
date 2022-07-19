using Mupsee.Models;

namespace Mupsee.Interfaces
{
    /// <summary>
    /// IEmailService
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Method for sending an email
        /// </summary>
        /// <param name="email"></param>
        public void SendEmail(EmailViewModel emailViewModel);
    }
}
