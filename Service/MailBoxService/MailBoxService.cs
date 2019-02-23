using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Dto.Mail;
using Helper.Mail;

namespace Service.MailBoxService
{
    public class MailBoxService : IMailBoxService
    {
        public List<MailDto> GetAllMessages(string serverAddress, int port, string mailAddress, string mailAddressPassword)
        {
            List<MailDto> retVal = new List<MailDto>();
            MailDto mailDto;

            List<MailMessage> mails = ImapMail.GetAllMails(new MailObj(serverAddress, port, mailAddress, mailAddressPassword));

            foreach (MailMessage mail in mails)
            {
                //todo:make new dto for getting messages
                mailDto = new MailDto
                {
                    SenderEmailAddress = mail.From.Address,
                    Message = mail.Body.ToString(),
                    ToEmailAddress = mail.To[0].Address

                };
                retVal.Add(mailDto);
            }

            return retVal;
        }
    }
}
