using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        /// Action for sending an email
        /// </summary>
        /// <param name="body"></param>
        [Authorize]
        [HttpPost("SendEmail")]
        public void SendEmail([FromBody] EmailViewModel emailViewModel)
        { 
            _emailService.SendEmail(emailViewModel);
        }
    }
}
