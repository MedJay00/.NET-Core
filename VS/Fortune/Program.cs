using Fortune.DependencyInjectionExample;
using System;
using Unity;

namespace Fortune
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IFortuneLoader, FromFileFortuneLoader>();
            container.RegisterType<IFortuneTeller, FortuneTeller>();
            container.RegisterType<IFortuneGetter, FortuneGetter>();
            container.RegisterType<IFortuneFacade, FortuneFacade>();

            var fortuneFacade = container.Resolve<IFortuneFacade>();

            Console.Write("Your fortune: "+fortuneFacade.TellF()+"\n");

            Console.Write("Write new your fortune\n");
            string fortune = Console.ReadLine();

            fortuneFacade.GetF(fortune);

            Console.Write("Your new fortune: "+fortuneFacade.TellF()+"\n");
       




        }
    }
}
