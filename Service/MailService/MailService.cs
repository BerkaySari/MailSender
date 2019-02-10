using System.Runtime.CompilerServices;
using Dto.Mail;
using Model;
using Model.Models;
using Repository.MailRepository;
using Helper;
using System.Threading.Tasks;

namespace Service.MailService
{
    class MailService : IMailService
    {
        private readonly IMailRepository _mailRepository;

        public MailService(IMailRepository mailRepository)
        {
            _mailRepository = mailRepository;
        }

        public void Add(MailDto mail)
        {
            //todo: fill another properties
            var mailTo = new MailTo
            {
                ToMailAddress = mail.ToEmailAddress,
                Message = mail.Message,
                Subject = mail.Subject,
                MailFrom = new MailFrom
                {
                    SenderMailAddress = mail.SenderEmailAddress,
                    SenderPassword = mail.SenderPassword
                }
            };

            _mailRepository.Add(mailTo);
        }

        public async Task SendMailAsync(MailDto mail)
        {
            await Helper.Mail.SendMail.SendMailAsync(mail);
            //Add(mail);
        }
    }
}
