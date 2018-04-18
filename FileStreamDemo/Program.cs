using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileStreamDemo
{
    public class XmlWriterReader
    {
        [STAThread]
    
        static void Main(string[] args)
        {
            string bestand = @"C:\\Temp\\gegevens.xml";
            XmlTextWriter schrijfXml = new XmlTextWriter(bestand,System.Text.Encoding.ASCII);
            schrijfXml.WriteStartDocument();
            schrijfXml.WriteStartElement("Klanten");
            WriteKlantInfo(schrijfXml,"001", "Jansen", "Utrecht");
            WriteKlantInfo(schrijfXml, "002", "Van Dam", "Amsterdam");
            schrijfXml.WriteEndDocument();

            schrijfXml.Close();

            XmlTextReader leesXml = new XmlTextReader(bestand);
            while ((leesXml.Read()))
            {
                if (leesXml.NodeType==XmlNodeType.Text)
                    Console.WriteLine(leesXml.Value);
            }
            leesXml.Close();
        }

        static void WriteKlantInfo(XmlTextWriter schrijver, string nummer, string achternaam, string woonplaats)
        {
            schrijver.WriteStartElement("Klant");
            schrijver.WriteAttributeString("nr ", nummer);
            schrijver.WriteElementString("Achternaam",achternaam);
            schrijver.WriteElementString("Woonplaats", woonplaats);
            schrijver.WriteEndElement();
        }
    }
}
