using Core.Entity;
using System;

namespace Model.Models
{
    public class MailTo : Entity<Guid>
    {
        public string ToMailAddress { get; set; }
        public string ToName { get; set; } // optional param
        public string ToSurname { get; set; } // optional param
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
