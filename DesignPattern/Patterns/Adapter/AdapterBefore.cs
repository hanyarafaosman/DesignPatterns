namespace DesignPattern.Adapter.Before
{
    // Old XML-based data source
    public class XmlDataSource
    {
        public string GetXmlData() => "<data>Hello</data>";
    }

    // Client code expects JSON
    public static class AdapterBefore
    {
        public static void Demo()
        {
            var xml = new XmlDataSource();
            // Problem: client needs JSON but only has XML source
            // Must manually parse/convert everywhere
            var rawXml = xml.GetXmlData();
            var manualJson = rawXml.Replace("<data>", "{\"data\":\"").Replace("</data>", "\"}");
            System.Console.WriteLine($"AdapterBefore: manual conversion => {manualJson}");
        }
    }
}
