using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Dto.Mail;

namespace Helper.Mail
{
    public class SendMail
    {
        public static async Task SendMailAsync(MailDto mailDto)
        {
            var smtpServer = new SmtpClient("smtp.gmail.com", 587);//todo add pop - imap clients
            var mail = new MailMessage { From = new MailAddress(mailDto.SenderEmailAddress) };
            mail.To.Add(mailDto.ToEmailAddress);
            mail.Subject = mailDto.Subject;
            mail.IsBodyHtml = true;

            var htmlBody = "";
            htmlBody += "<div>" + mailDto.Message + "</div>";

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlBody, null, "text/html");
            mail.AlternateViews.Add(htmlView);


            mail.Body = htmlBody;
            smtpServer.UseDefaultCredentials = false;

            smtpServer.Credentials = new NetworkCredential(mailDto.SenderEmailAddress, mailDto.SenderPassword);
            smtpServer.EnableSsl = true;

            await smtpServer.SendMailAsync(mail);
        }
    }
}
