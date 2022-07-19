using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Mupsee.Interfaces;
using Mupsee.Models;
using Mupsee.Models.SettingsModels;

namespace Mupsee.Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _emailConfiguration;
        public EmailService(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration.Value;
        }

        public void SendEmail(EmailViewModel emailViewModel)
        {
            if (emailViewModel is null)
                throw new ArgumentNullException($"Argument {emailViewModel} cannot be null or empty");

            try
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_emailConfiguration.Sender));
                //email.To.Add(MailboxAddress.Parse("[ADD EMAIL RECIPIENT]"));
                message.To.Add(MailboxAddress.Parse(_emailConfiguration.EmailRecipient));
                message.Subject = emailViewModel.Subject;
                message.Body = new TextPart(TextFormat.Html) { Text = emailViewModel.Body };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(_emailConfiguration.Smtp, _emailConfiguration.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfiguration.EmailRecipient, _emailConfiguration.Password);
                //smtp.Authenticate("[ADD EMAIL RECIPIENT]", "[ADD EMAIL PASSWORD]");
                smtp.Send(message);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
