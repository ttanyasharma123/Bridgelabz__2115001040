using System;
using System.Xml;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Sample JSON Data
        string json = @"{
            'Person': {
                'Name': 'Tanya Sharma',
                'Email': 'tanya@example.com',
                'Age': 22,
                'City': 'Delhi'
            }
        }";

        // Convert JSON to XML
        XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(json, "Root");

        // Print XML Output
        Console.WriteLine("Converted XML:");
        Console.WriteLine(xmlDoc.OuterXml);

        // Save XML to a file (optional)
        xmlDoc.Save("output.xml");
        Console.WriteLine("XML saved to output.xml");
    }
}



