namespace DesignPattern.Command.Before
{
    public class Light
    {
        public void TurnOn() => System.Console.WriteLine("  Light is ON");
        public void TurnOff() => System.Console.WriteLine("  Light is OFF");
    }

    public class RemoteControl
    {
        public void PressButton(Light light, string action)
        {
            // Problem: control logic is tightly coupled to Light
            // Adding new devices requires modifying this class
            if (action == "on") light.TurnOn();
            else if (action == "off") light.TurnOff();
        }
    }

    public static class CommandBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("CommandBefore:");
            var remote = new RemoteControl();
            var light = new Light();
            remote.PressButton(light, "on");
            remote.PressButton(light, "off");
        }
    }
}
