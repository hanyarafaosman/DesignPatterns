namespace DesignPattern.Facade.After
{
    public class CPU
    {
        public void Freeze() => System.Console.WriteLine("  CPU: Freeze");
        public void Jump(long position) => System.Console.WriteLine($"  CPU: Jump to {position}");
        public void Execute() => System.Console.WriteLine("  CPU: Execute");
    }

    public class Memory
    {
        public void Load(long position, byte[] data) => System.Console.WriteLine($"  Memory: Load at {position}");
    }

    public class HardDrive
    {
        public byte[] Read(long lba, int size) { System.Console.WriteLine($"  HardDrive: Read {size} bytes"); return new byte[size]; }
    }

    // Facade simplifies the complex subsystem
    public class ComputerFacade
    {
        private readonly CPU _cpu = new();
        private readonly Memory _memory = new();
        private readonly HardDrive _hd = new();

        public void Start()
        {
            _cpu.Freeze();
            _memory.Load(0, _hd.Read(0, 1024));
            _cpu.Jump(0);
            _cpu.Execute();
        }
    }

    public static class FacadeAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("FacadeAfter:");
            var computer = new ComputerFacade();
            computer.Start(); // Simple interface
        }
    }
}
