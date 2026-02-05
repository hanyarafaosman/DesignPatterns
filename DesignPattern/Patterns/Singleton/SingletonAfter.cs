namespace DesignPattern.Singleton
{
    public sealed class SettingsSingleton
    {
        private static readonly SettingsSingleton _instance = new SettingsSingleton();
        public string Mode { get; set; }
        private SettingsSingleton() { Mode = "Default"; }
        public static SettingsSingleton Instance => _instance;
    }

    public static class SingletonAfter
    {
        public static void Demo()
        {
            SettingsSingleton.Instance.Mode = "X";
            var s2 = SettingsSingleton.Instance;
            System.Console.WriteLine($"SingletonAfter: Instance.Mode={s2.Mode}");
        }
    }
}
