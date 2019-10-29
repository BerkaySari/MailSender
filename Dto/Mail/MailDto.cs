using Microsoft.AspNetCore.Mvc;

namespace Dto.Mail
{
    public class MailDto
    {
        [BindProperty]
        public string ToEmailAddress { get; set; }
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public string Subject { get; set; }
        [BindProperty]
        public string SenderEmailAddress { get; set; }
        [BindProperty]
        public string SenderPassword { get; set; }
    }

    public class MailCredential
    {
        [BindProperty]
        public string ServerAddress { get; set; }
        [BindProperty]
        public int Port { get; set; }
        [BindProperty]
        public string MailAddress { get; set; }
        [BindProperty]
        public string MailAddressPassword { get; set; }
    }
}
