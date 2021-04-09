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
    [ApiExplorerSettings(IgnoreApi = true)]
    public class EmailController : Controller
    {
        private ApplicationDbContext _dbContext;
        public EmailController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/test")]
        public IActionResult Email()
        {
            foreach (var subscriber in _dbContext.NewsletterEmails)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("real.jan.maruscak@gmail.com"));
                message.To.Add(new MailboxAddress(subscriber.EmailAddress));
                message.Subject = Database.Articles().First().Title;

                message.Body = new TextPart("plain")
                {
                    Text = Database.Articles().First().Content
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("real.jan.maruscak@gmail.com", GmailPassword);

                    client.Send(message);
                    client.Disconnect(true);
                }
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
