using Core.Entity;
using System;

namespace Model.Models
{
    public class MailInfo : Entity<Guid>
    {
        public string MailAddress { get; set; }
        public string Password { get; set; } //todo: save password with sha1 + md5
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
