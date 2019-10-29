using S22.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;


namespace Helper.Mail
{
    public class ImapMail
    {
        public static List<MailMessage> GetAllMails(MailObj mObj)
        {
            using (ImapClient Client = new ImapClient(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                IEnumerable<uint> uids = Client.Search(SearchCondition.All());
                return Client.GetMessages(uids).ToList();
            }
        }

        public List<MailMessage> GetUnseenMails(MailObj mObj)
        {
            using (ImapClient Client = new ImapClient(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                IEnumerable<uint> uids = Client.Search(SearchCondition.Unseen());
                return Client.GetMessages(uids).ToList();
            }
        }

        public List<MailMessage> GetAllMailHeaders(MailObj mObj)
        {
            using (ImapClient Client = new ImapClient(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                IEnumerable<uint> uids = Client.Search(SearchCondition.All());
                return Client.GetMessages(uids, FetchOptions.HeadersOnly).ToList();
            }
        }

        public List<MailMessage> GetUnseenMailHeaders(MailObj mObj)
        {
            using (ImapClient Client = new ImapClient(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                IEnumerable<uint> uids = Client.Search(SearchCondition.Unseen());
                return Client.GetMessages(uids, FetchOptions.HeadersOnly).ToList();
            }
        }




        public static List<MailMessage> SearchMessages(MailObj mObj, string searchFrom, string searchSubject, string searchText, string searchKeyword)
        {
            using (ImapClient Client = new ImapClient(mObj.ServerAddress, mObj.Port, mObj.MailAddress, mObj.MailAddressPassword, AuthMethod.Login, true))
            {
                List<SearchCondition> scList = new List<SearchCondition>();

                if (!string.IsNullOrWhiteSpace(searchFrom))
                    scList.Add(SearchCondition.From(searchFrom));
                if (!string.IsNullOrWhiteSpace(searchSubject))
                    scList.Add(SearchCondition.Subject(searchSubject));
                if (!string.IsNullOrWhiteSpace(searchText))
                    scList.Add(SearchCondition.Text(searchText));
                if (!string.IsNullOrWhiteSpace(searchKeyword))
                    scList.Add(SearchCondition.Keyword(searchKeyword));


                if (scList.Count > 0)
                {
                    SearchCondition allConditions = scList[0];
                    for (int i = 1; i < scList.Count; i++)
                        allConditions.And(scList[i]);

                    IEnumerable<uint> uids = Client.Search(allConditions);
                    return Client.GetMessages(uids).ToList();
                }

                return new List<MailMessage>();
            }
        }
    }
}
