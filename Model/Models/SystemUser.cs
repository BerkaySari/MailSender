using Core.Entity;
using System;

namespace Model.Models
{
    public class MailRepository : Entity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; } //todo: save password with sha1 + md5
        public string UserName { get; set; }
        public string MailAddress { get; set; }
    }
}
