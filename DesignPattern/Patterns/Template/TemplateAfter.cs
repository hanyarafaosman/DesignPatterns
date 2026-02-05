namespace DesignPattern.Template.After
{
    public abstract class BeverageRecipe
    {
        // Template method defines the skeleton
        public void Make()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        private void BoilWater() => System.Console.WriteLine("  Boil water");
        private void PourInCup() => System.Console.WriteLine("  Pour in cup");

        protected abstract void Brew();
        protected abstract void AddCondiments();
    }

    public class Coffee : BeverageRecipe
    {
        protected override void Brew() => System.Console.WriteLine("  Brew coffee grounds");
        protected override void AddCondiments() => System.Console.WriteLine("  Add sugar");
    }

    public class Tea : BeverageRecipe
    {
        protected override void Brew() => System.Console.WriteLine("  Steep tea bag");
        protected override void AddCondiments() => System.Console.WriteLine("  Add lemon");
    }

    public static class TemplateAfter
    {
        public static void Demo()
        {
            System.Console.WriteLine("TemplateAfter Coffee:");
            new Coffee().Make();
            System.Console.WriteLine("TemplateAfter Tea:");
            new Tea().Make();
        }
    }
}
