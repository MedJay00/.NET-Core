using Infestation.Infra.Services.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace Infestation.Infra.Services.Implementations
{
    public class MessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public MessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(string recipient, string bodyMessage)
        {
            if(recipient.Contains("@"))
            {
                MimeMessage message = new MimeMessage();

                message.From.Add(new MailboxAddress("Admin", _configuration.GetValue<string>("EmailAddress")));
                message.To.Add(new MailboxAddress("User", recipient));

                message.Subject = "email from admin";

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = bodyMessage;
                bodyBuilder.HtmlBody = "<h1>"+ bodyMessage + "</h1>";
                message.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate(_configuration.GetValue<string>("EmailAddress"), _configuration.GetValue<string>("EmailPassword"));

                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            else 
            {
                TwilioClient.Init(_configuration.GetValue<string>("TwilioAccountSid"), _configuration.GetValue<string>("TwilioAuthToken"));

                var message = MessageResource.Create(
                    body: bodyMessage,
                    from: new Twilio.Types.PhoneNumber(_configuration.GetValue<string>("PhoneNumber")),
                    to: new Twilio.Types.PhoneNumber(recipient)
                );
            }

           

        }
    }
}
