using System;
using System.Collections.Generic;
using System.Text;

namespace Fortune.DependencyInjectionExample
{
    interface IFortuneFacade
    {
        public string TellF();

        public void GetF(string text);
    }
}
