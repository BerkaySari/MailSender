using System.Linq;
using S22.Pop3;
using System.Net.Mail;
using System.Collections.Generic;

namespace Helper.Mail
{
    public class Pop3Mail
    {
        public List<MailMessage> GetAllMails(MailObj mObj)
        {
            using (Pop3Client Client = new Pop3Client(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                return Client.GetMessages().ToList();
            }
        }

        public List<MailMessage> GetAllMailHeaders(MailObj mObj)
        {
            using (Pop3Client Client = new Pop3Client(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                return Client.GetMessages(null, FetchOptions.HeadersOnly).ToList();
            }
        }
    }
}
