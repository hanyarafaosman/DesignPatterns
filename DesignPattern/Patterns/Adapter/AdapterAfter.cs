namespace DesignPattern.Adapter.After
{
    // Target interface the client expects
    public interface IJsonDataSource
    {
        string GetJsonData();
    }

    // Existing XML source (cannot modify)
    public class XmlDataSource
    {
        public string GetXmlData() => "<data>Hello</data>";
    }

    // Adapter wraps XML source and exposes JSON interface
    public class XmlToJsonAdapter : IJsonDataSource
    {
        private readonly XmlDataSource _xmlSource;
        public XmlToJsonAdapter(XmlDataSource xmlSource) { _xmlSource = xmlSource; }

        public string GetJsonData()
        {
            var xml = _xmlSource.GetXmlData();
            // Conversion logic encapsulated here
            return xml.Replace("<data>", "{\"data\":\"").Replace("</data>", "\"}");
        }
    }

    public static class AdapterAfter
    {
        public static void Demo()
        {
            IJsonDataSource source = new XmlToJsonAdapter(new XmlDataSource());
            System.Console.WriteLine($"AdapterAfter: {source.GetJsonData()}");
        }
    }
}
