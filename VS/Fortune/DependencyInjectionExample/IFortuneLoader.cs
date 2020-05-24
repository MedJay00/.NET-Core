namespace Fortune
{
    public interface IFortuneLoader
    {
        public string LoadFortune();

        public void UnloadFortune (string text);
    }
}
