using Infestation.Infra.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Infestation.Infra.Services.Implementations
{
    public class SmsService : IMessageService
    {
        public IConfiguration _configuration { get; set; }
        public SmsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage(string recipient, string bodyMessage)
        {
            TwilioClient.Init(_configuration.GetValue<string>("TwilioAccountSid"), _configuration.GetValue<string>("TwilioAuthToken"));

            var message = MessageResource.Create(
                body: "Hi there!",
                from: new Twilio.Types.PhoneNumber("+18647320603"),
                to: new Twilio.Types.PhoneNumber("+380933596232")
            );
        }
    }
}
