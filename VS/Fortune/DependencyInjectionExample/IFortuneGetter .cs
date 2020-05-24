using System;
using System.Collections.Generic;
using System.Text;

namespace Fortune.DependencyInjectionExample
{
    interface IFortuneGetter
    {
        public void GetFortune(String name);
    }
}
