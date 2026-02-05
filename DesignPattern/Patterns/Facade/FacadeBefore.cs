namespace DesignPattern.Facade.Before
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

    public static class FacadeBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("FacadeBefore:");
            // Problem: client must know complex subsystem interactions
            var cpu = new CPU();
            var memory = new Memory();
            var hd = new HardDrive();

            cpu.Freeze();
            memory.Load(0, hd.Read(0, 1024));
            cpu.Jump(0);
            cpu.Execute();
        }
    }
}
