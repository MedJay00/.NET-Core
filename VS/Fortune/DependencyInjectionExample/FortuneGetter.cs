using System;
using System.Collections.Generic;
using System.Text;

namespace Fortune.DependencyInjectionExample
{
    class FortuneGetter : IFortuneGetter
    {
        private IFortuneLoader _fortuneLoader;

        public FortuneGetter(IFortuneLoader fortuneLoader)
        {
            _fortuneLoader = fortuneLoader;
        }

        public void GetFortune(string name)
        {
            _fortuneLoader.UnloadFortune(name);
        }
    }
}
