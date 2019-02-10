using Dto.Mail;
using Microsoft.AspNetCore.Mvc;
using Service.MailService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSenderExample.Controllers
{
    [Route("api/[controller]")]
    public class MailSenderController : Controller
    {
        private IMailService _IMailService;
        public MailSenderController(IMailService IMailService)
        {
            _IMailService = IMailService;
        }


        [HttpGet("[action]")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<MailDto>))]
        [ProducesResponseType(404)]
        public IActionResult SendMailController(MailDto mailDto)
        {
            try
            {
                return Ok(_IMailService.SendMailAsync(mailDto));
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }
        }
    }
}
