namespace Mupsee.Models
{
    public class EmailConfiguration
    {
        public string EmailRecipient { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }
    }
}
