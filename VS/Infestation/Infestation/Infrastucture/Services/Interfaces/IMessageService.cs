using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Infra.Services.Interfaces
{
   public interface IMessageService
    {
        void SendMessage(string recipient, string bodyMessage);
    }

    //public class Email { }
    //public class Sms { }
}
