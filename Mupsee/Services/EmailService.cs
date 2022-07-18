using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using Mupsee.Interfaces;
using Mupsee.Models;

namespace Mupsee.Services
{
    public class EmailService : IEmailService
    {
        private EmailConfiguration _emailConfiguration;
        public EmailService(IOptions<EmailConfiguration> settings)
        {
            _emailConfiguration = settings.Value;
        }

        public void SendEmail(string subject, string body)
        {
            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentNullException($"Argument {subject} cannot be null or empty");

            if (string.IsNullOrWhiteSpace(subject))
                throw new ArgumentNullException($"Argument {body} cannot be null or empty");

            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_emailConfiguration.Sender));
                //email.To.Add(MailboxAddress.Parse("[ADD EMAIL RECIPIENT]"));
                email.To.Add(MailboxAddress.Parse(_emailConfiguration.EmailRecipient));
                email.Subject = subject;
                email.Body = new TextPart(TextFormat.Html) { Text = body };

                // send email
                using var smtp = new SmtpClient();
                smtp.Connect(_emailConfiguration.Smtp, _emailConfiguration.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfiguration.EmailRecipient, _emailConfiguration.Password);
                //smtp.Authenticate("[ADD EMAIL RECIPIENT]", "[ADD EMAIL PASSWORD]");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
