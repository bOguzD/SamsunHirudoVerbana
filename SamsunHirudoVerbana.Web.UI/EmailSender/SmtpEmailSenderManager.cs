using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Web.UI.EmailSender
{
    public class SmtpEmailSenderManager : IEmailSender
    {
        private string _host;
        private int _port;
        private bool _enableSSL;
        private string _userName;
        private string _password;
        private string _displayName;

        public SmtpEmailSenderManager(string host, int port, bool enableSSL, string UserName, string Password)
        {
            _host = host;
            _port = port;
            _enableSSL = enableSSL;
            _userName = UserName;
            _password = Password;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient(this._host, this._port) {
                Credentials = new NetworkCredential(_userName, _password),
                EnableSsl = this._enableSSL
            };
            return client.SendMailAsync(
                new MailMessage(this._userName, email, subject, htmlMessage) {
                    From = new MailAddress(_userName, "Samsun Hirudo Verbana"),
                    IsBodyHtml = true
                });
        }
    }
}
