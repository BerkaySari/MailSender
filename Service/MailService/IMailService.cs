using Dto.Mail;
using System.Threading.Tasks;

namespace Service.MailService
{
    public interface IMailService
    {
        void Add(MailDto mail);
        Task SendMailAsync(MailDto mail);
    }
}
