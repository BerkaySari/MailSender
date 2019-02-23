using Dto.Mail;
using Microsoft.AspNetCore.Mvc;
using Service.MailBoxService;
using System;

namespace MailSenderExample.Controllers
{
    [Route("api/[controller]")]
    public class MailBoxController : Controller
    {
        private IMailBoxService _IMailBoxService;
        public MailBoxController(IMailBoxService IMailBoxService)
        {
            _IMailBoxService = IMailBoxService;
        }

        
        //https://localhost:44368/api/MailBox/GetAllMails
        [HttpGet("[action]")]
        public IActionResult GetAllMails(string serverAddress, int port, string mailAddress, string mailAddressPassword)
        {
            try
            {
                return Ok(_IMailBoxService.GetAllMessages(serverAddress, port, mailAddress, mailAddressPassword));
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }
    }
}
