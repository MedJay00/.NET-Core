using Castle.Core.Configuration;
using Infestation.Infra.Services.Interfaces;
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

        public void SendMessage()
        {
            const string accountSid = "AC9842d551162aa0d92f8fc31818015b38";
            const string authToken = "257fbd7a7c7fa79dd071446d1b51a69a";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Hi there!",
                from: new Twilio.Types.PhoneNumber("+18647320603"),
                to: new Twilio.Types.PhoneNumber("+15558675310")
            );

            Console.WriteLine(message.Sid);
        }
    }
}
