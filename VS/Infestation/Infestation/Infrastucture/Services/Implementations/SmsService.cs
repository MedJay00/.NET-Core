using Infestation.Infra.Services.Interfaces;
using Infestation.Infrastucture.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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

        InfestationConfiguration _infestationConfiguration { get; set; }

        public SmsService(IConfiguration configuration, IOptions<InfestationConfiguration> options)
        {
            _configuration = configuration;

            _infestationConfiguration = options.Value;
        }

        public void SendMessage(string recipient, string bodyMessage)
        {

            TwilioClient.Init(_infestationConfiguration.SmsService.TwilioAccountSid, _infestationConfiguration.SmsService.TwilioAuthToken);

            var message = MessageResource.Create(
                body: bodyMessage,
                from: new Twilio.Types.PhoneNumber(_infestationConfiguration.SmsService.PhoneNumber),
                to: new Twilio.Types.PhoneNumber(recipient)
            );

        }
    }
}
