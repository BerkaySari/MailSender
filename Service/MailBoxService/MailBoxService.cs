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

            //List<MailMessage> mails3 = ImapMail.SearchMessages(new MailObj(serverAddress, port, mailAddress, mailAddressPassword), "", "ek", "", "");

            foreach (MailMessage mail in mails)
            {
                mailDto = new MailDto
                {
                    SenderEmailAddress = mail.From.Address,
                    Message = mail.Body.ToString(),
                    ToEmailAddress = mail.To[0].Address,
                    Subject = mail.Subject
                };
                retVal.Add(mailDto);
            }

            return retVal;
        }
    }
}
