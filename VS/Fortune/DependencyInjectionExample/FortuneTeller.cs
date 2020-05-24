using System;

namespace Fortune
{
    public class FortuneTeller : IFortuneTeller
    {
        private IFortuneLoader _fortuneLoader;

        public FortuneTeller(IFortuneLoader fortuneLoader)
        {
            _fortuneLoader = fortuneLoader;
        }

        public string TellFortune()
        {
            return _fortuneLoader.LoadFortune();
            
        }
    }
}
