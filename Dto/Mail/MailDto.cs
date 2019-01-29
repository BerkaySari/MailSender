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
}
