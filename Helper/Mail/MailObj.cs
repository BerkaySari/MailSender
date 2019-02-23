using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Mail
{
    public class MailObj
    {
        public string ServerAddress { get; set; }
        public int Port { get; set; }
        public string MailAddress { get; set; }
        public string MailAddressPassword { get; set; }

        public MailObj(string _serverAddress, int _port, string _mailAddress, string _mailAddressPassword)
        {
            ServerAddress = _serverAddress;
            Port = _port;
            MailAddress = _mailAddress;
            MailAddressPassword = _mailAddressPassword;
        }
    }
}
