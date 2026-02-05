namespace DesignPattern.Singleton
{
    /// <summary>
    /// Regular class that can be instantiated multiple times.
    /// This represents the PROBLEM that Singleton pattern solves.
    /// </summary>
    public class Settings
    {
        public string Mode { get; set; }
    }

    /// <summary>
    /// Demonstrates the problem: Multiple instances lead to inconsistent state.
    /// 
    /// Problem Scenario:
    /// - Different parts of the application create separate Settings instances
    /// - Each instance has its own state (s1.Mode = "A", s2.Mode = "B")
    /// - No shared state between instances
    /// - Changes to one instance don't affect others
    /// 
    /// Real-World Issues:
    /// - Configuration drift: Different parts use different configs
    /// - Resource waste: Multiple database connections, file handles
    /// - Race conditions: Concurrent access to shared resources
    /// - Testing difficulties: Hard to control global state
    /// </summary>
    public static class SingletonBefore
    {
        public static void Demo()
        {
            // Problem: Each 'new' creates a separate instance
            var s1 = new Settings { Mode = "A" };
            var s2 = new Settings { Mode = "B" };
            
            // Output shows different values - inconsistent state!
            System.Console.WriteLine($"SingletonBefore: s1.Mode={s1.Mode}, s2.Mode={s2.Mode}");
            // Expected output: "SingletonBefore: s1.Mode=A, s2.Mode=B"
            // This is BAD because we want ONE shared configuration
        }
    }
}
