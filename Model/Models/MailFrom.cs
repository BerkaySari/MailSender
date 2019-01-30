using Core.Entity;
using System;

namespace Model.Models
{
    public class MailFrom : Entity<Guid>
    {
        public string SenderMailAddress { get; set; }
        public string SenderPassword { get; set; } //todo: save password with sha1 + md5
        public string SenderName { get; set; } // optional param
        public string SenderSurname { get; set; } // optional param
        public MailRepository SystemUser { get; set; }
    }
}
