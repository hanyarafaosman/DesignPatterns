namespace DesignPattern.Command.After
{
    public interface ICommand
    {
        void Execute();
    }

    public class Light
    {
        public void TurnOn() => System.Console.WriteLine("  Light is ON");
        public void TurnOff() => System.Console.WriteLine("  Light is OFF");
    }

    public class LightOnCommand : ICommand
    {
        private readonly Light _light;
        public LightOnCommand(Light light) { _light = light; }
        public void Execute() => _light.TurnOn();
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;
        public LightOffCommand(Light light) { _light = light; }
        public void Execute() => _light.TurnOff();
    }

    public class RemoteControl
    {
        private ICommand? _command;
        public void SetCommand(ICommand command) => _command = command;
        public void PressButton() => _command?.Execute();
    }

    public static class CommandAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("CommandAfter:");
            var light = new Light();
            var remote = new RemoteControl();

            remote.SetCommand(new LightOnCommand(light));
            remote.PressButton();

            remote.SetCommand(new LightOffCommand(light));
            remote.PressButton();
        }
    }
}
