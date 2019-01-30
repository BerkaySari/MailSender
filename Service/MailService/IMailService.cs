using Dto.Mail;

namespace Service.MailService
{
    public interface IMailService
    {
        void Add(MailDto mail);
    }
}
