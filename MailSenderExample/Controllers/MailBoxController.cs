using Dto.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.MailBoxService;
using System;
using System.IO;
using System.Text;

namespace MailSenderExample.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class MailBoxController : Controller
    {
        private IMailBoxService _IMailBoxService;
        public MailBoxController(IMailBoxService IMailBoxService)
        {
            _IMailBoxService = IMailBoxService;
        }

        
        //https://localhost:44368/api/MailBox/GetAllMails
        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(bool))]
        //[HttpGet("[action]")]
        public IActionResult GetAllMails([FromBody]MailCredential pd)
        {
            try
            {
                return Ok(_IMailBoxService.GetAllMessages(pd.ServerAddress, pd.Port, pd.MailAddress, pd.MailAddressPassword));
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }
    }
}
