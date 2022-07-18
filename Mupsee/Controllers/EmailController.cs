using Microsoft.AspNetCore.Mvc;
using Mupsee.Interfaces;

namespace Mupsee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public void SendEmail(string subject, string body)
        { 
            _emailService.SendEmail(subject, body);
        }
    }
}
