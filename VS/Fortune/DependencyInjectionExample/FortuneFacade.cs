using System;
using System.Collections.Generic;
using System.Text;

namespace Fortune.DependencyInjectionExample
{
    class FortuneFacade : IFortuneFacade
    {
        private FortuneTeller _fortuneTeller;

        private FortuneGetter _fortuneGetter;

        public FortuneFacade(FortuneTeller fortuneTeller, FortuneGetter fortuneGetter)
        {
            _fortuneTeller = fortuneTeller;

            _fortuneGetter = fortuneGetter;
        }

        public string TellF()
        {
            return _fortuneTeller.TellFortune();
        }

        public void GetF(string text)
        {
            _fortuneGetter.GetFortune(text);
        }

        
    }
}
