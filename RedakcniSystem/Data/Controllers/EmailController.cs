using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedakcniSystem.Data.Models;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using static RedakcniSystem.Ignore;

namespace RedakcniSystem.Data.Controllers
{
    public class EmailController : Controller
    {

        [Route("/test")]
        public IActionResult Email()
        {
            var message = new MimeMessage ();
            message.From.Add (new MailboxAddress ("Jan Maruscak", "real.jan.maruscak@gmail.com"));
            message.To.Add (new MailboxAddress (Database.Emails().First().ToString()));
            message.Subject = Database.Articles().First().Title;

            message.Body = new TextPart ("plain") {
                Text = Database.Articles().First().Content
            };

            using (var client = new SmtpClient ()) {
                client.Connect ("smtp.gmail.com", 465, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate ("real.jan.maruscak@gmail.com", GmailPassword);

                client.Send (message);
                client.Disconnect (true);
            }
            return View(new MailModel()
            {
                Email = Database.Emails().First(),
                Text = Database.Articles().First().Content,
                Title = Database.Articles().First().Title,
            });
            
        }
    }
}
