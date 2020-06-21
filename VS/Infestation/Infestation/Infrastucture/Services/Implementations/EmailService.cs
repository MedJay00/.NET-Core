using Infestation.Infra.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infra.Services.Implementations
{
    public class EmailService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(string recipient, string bodyMessage)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("Admin", _configuration.GetValue<string>("EmailAddress")));
            message.To.Add(new MailboxAddress("User", "wapona8153@royandk.com"));

            message.Subject = "email from admin";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Hello from Admin";
            bodyBuilder.HtmlBody = "<h1>Hello from Admin</h1>";
            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                client.Connect("smtp.gmail.com",465,true);
                client.Authenticate(_configuration.GetValue<string>("EmailAddress"), _configuration.GetValue<string>("EmailPassword"));

                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
