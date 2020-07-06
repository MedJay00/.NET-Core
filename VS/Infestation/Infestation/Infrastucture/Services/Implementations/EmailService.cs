using Infestation.Infra.Services.Interfaces;
using Infestation.Infrastucture.Configuration;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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

        InfestationConfiguration _infestationConfiguration { get; set; }

        public EmailService(IConfiguration configuration, IOptions<InfestationConfiguration> options)
        {
            _configuration = configuration;

            _infestationConfiguration = options.Value;
        }

        public void SendMessage(string recipient, string bodyMessage)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress(_infestationConfiguration.EmailService.FromName, _infestationConfiguration.EmailService.EmailAddress));
            message.To.Add(new MailboxAddress(_infestationConfiguration.EmailService.ToName, recipient));

            message.Subject = _infestationConfiguration.EmailService.Subject;

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = bodyMessage;
            bodyBuilder.HtmlBody = _infestationConfiguration.HOne + bodyMessage + _infestationConfiguration.HOne;
            message.Body = bodyBuilder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                client.Connect(_infestationConfiguration.EmailService.GoogleSmptServer, _infestationConfiguration.EmailService.Port, true);
                client.Authenticate(_infestationConfiguration.EmailService.EmailAddress, _infestationConfiguration.EmailService.EmailPassword);

                client.Send(message);
                client.Disconnect(true);
            }


        }
    }
}
