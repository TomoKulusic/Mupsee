namespace Mupsee.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(string subject, string body);
    }
}
