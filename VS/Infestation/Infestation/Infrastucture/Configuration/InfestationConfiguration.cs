using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infrastucture.Configuration
{
    public class InfestationConfiguration
    {
        public string TestEmail { get; set; }
        public int CacheTime { get; set; }
        public string HOne { get; set; }

        public EmailServiceConfiguration EmailService { get; set; } = new EmailServiceConfiguration();
        public SmsServiceConfiguration SmsService { get; set; } = new SmsServiceConfiguration();
    }

    public class EmailServiceConfiguration
    {
        public int Port { get; set; }
        public string GoogleSmptServer { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string Subject { get; set; }
        public string EmailAddress { get; set; }
        public string EmailPassword { get; set; }

    }

    public class SmsServiceConfiguration
    {
        public string TwilioAccountSid { get; set; }
        public string TwilioAuthToken { get; set; }
        public string PhoneNumber { get; set; }
    }

}
