using System.IO;

namespace Fortune
{
    public class FromFileFortuneLoader : IFortuneLoader
    {
        
        public string LoadFortune() 
        {
            return File.ReadAllText(@"..\..\..\res\Fortune.txt");
        }

        public void UnloadFortune(string text)
        {
            File.WriteAllText(@"..\..\..\res\Fortune.txt",text);
        }
    }
}
