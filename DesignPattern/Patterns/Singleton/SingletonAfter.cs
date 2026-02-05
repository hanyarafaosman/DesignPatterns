namespace DesignPattern.Singleton
{
    /// <summary>
    /// Singleton implementation ensuring only ONE instance exists throughout the application.
    /// 
    /// Key Components:
    /// 1. Private static field: Holds the single instance
    /// 2. Private constructor: Prevents external instantiation
    /// 3. Public static property: Provides global access point
    /// 4. sealed keyword: Prevents inheritance
    /// 
    /// Thread Safety:
    /// - Static field initialization is thread-safe in C# (CLR guarantee)
    /// - Instance created once before any threads access it
    /// - No locks needed (Eager Initialization pattern)
    /// 
    /// Benefits:
    /// ✅ Guaranteed single instance
    /// ✅ Lazy or eager initialization
    /// ✅ Global access point
    /// ✅ Thread-safe (with proper implementation)
    /// </summary>
    public sealed class SettingsSingleton  // 'sealed' prevents inheritance
    {
        // Static field: Created once when class is first accessed (thread-safe)
        private static readonly SettingsSingleton _instance = new SettingsSingleton();
        
        // Public property for state (shared across all accesses)
        public string Mode { get; set; }
        
        // Private constructor: Prevents 'new SettingsSingleton()' from outside
        private SettingsSingleton() 
        { 
            Mode = "Default";  // Initialize with default state
        }
        
        // Global access point: Returns the SAME instance every time
        public static SettingsSingleton Instance => _instance;
    }

    /// <summary>
    /// Demonstrates the solution: Single instance ensures consistent state.
    /// 
    /// Solution Benefits:
    /// - All code accesses the SAME instance
    /// - Changes are visible everywhere
    /// - Resource efficiency (one database connection, one config, etc.)
    /// - Predictable behavior
    /// 
    /// Use Cases:
    /// - Configuration managers
    /// - Logging services
    /// - Database connection pools
    /// - Cache managers
    /// - Hardware interface access (printer, GPU)
    /// </summary>
    public static class SingletonAfter
    {
        public static void Demo()
        {
            // First access: Set shared state
            SettingsSingleton.Instance.Mode = "X";
            
            // Second access: Get the SAME instance (not a new one!)
            var s2 = SettingsSingleton.Instance;
            
            // Output shows same value - consistent state!
            System.Console.WriteLine($"SingletonAfter: Instance.Mode={s2.Mode}");
            // Output: "SingletonAfter: Instance.Mode=X"
            // Both accesses see Mode="X" because they share the same instance
        }
    }
}
