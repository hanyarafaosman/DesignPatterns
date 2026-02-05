namespace DesignPattern.Singleton
{
    public class Settings
    {
        public string Mode { get; set; }
    }

    public static class SingletonBefore
    {
        public static void Demo()
        {
            var s1 = new Settings { Mode = "A" };
            var s2 = new Settings { Mode = "B" };
            System.Console.WriteLine($"SingletonBefore: s1.Mode={s1.Mode}, s2.Mode={s2.Mode}");
        }
    }
}
