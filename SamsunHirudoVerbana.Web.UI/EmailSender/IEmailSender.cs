using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Web.UI.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
