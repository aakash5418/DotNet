using System.Xml;
using System.Configuration;
namespace writeXmlFile
{
    class XmlFile
    {
        public static void Main()
        {
            string filename = ConfigurationSettings.AppSettings["xmlFile"];
            XmlTextWriter xmlTextWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteComment("creating a xml file using c#");
            xmlTextWriter.WriteStartElement("Employees");

            for (int i = 1; i <= 3; i++)
            {
                xmlTextWriter.WriteStartElement("Employee");

                Console.WriteLine("Enter the ID for Employee" + i);
                xmlTextWriter.WriteElementString("ID", Console.ReadLine());

                Console.WriteLine("Enter the Name for Employee" + i);
                xmlTextWriter.WriteElementString("Name", Console.ReadLine());

                Console.WriteLine("Enter the Department for Employee" + i);
                xmlTextWriter.WriteElementString("Department", Console.ReadLine());

                xmlTextWriter.WriteEndElement();
            }
            
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
        }
    }
}
