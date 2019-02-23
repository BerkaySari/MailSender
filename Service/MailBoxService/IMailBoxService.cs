using Dto.Mail;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Service.MailBoxService
{
    public interface IMailBoxService
    {
        List<MailDto> GetAllMessages(string serverAddress, int port, string mailAddress, string mailAddressPassword);
    }
}
