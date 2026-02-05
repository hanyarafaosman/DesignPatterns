namespace DesignPattern.Template.Before
{
    public class CoffeeRecipe
    {
        public void Make()
        {
            System.Console.WriteLine("  Boil water");
            System.Console.WriteLine("  Brew coffee grounds");
            System.Console.WriteLine("  Pour in cup");
            System.Console.WriteLine("  Add sugar");
        }
    }

    public class TeaRecipe
    {
        public void Make()
        {
            System.Console.WriteLine("  Boil water");
            System.Console.WriteLine("  Steep tea bag");
            System.Console.WriteLine("  Pour in cup");
            System.Console.WriteLine("  Add lemon");
        }
    }

    public static class TemplateBefore
    {
        public static void Demo()
        {
            System.Console.WriteLine("TemplateBefore Coffee:");
            new CoffeeRecipe().Make();
            System.Console.WriteLine("TemplateBefore Tea:");
            new TeaRecipe().Make();
            // Problem: duplicated steps (boil, pour) across classes
        }
    }
}
