using System;
using System.Collections.Generic;

using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EVotingProject.Helpers
{
    class ReadXmlHelper
    {
        private static XDocument docXml;
        // private static XElement elemXml;
        public static void loadXml(string filePath)
        {
            docXml = XDocument.Load(filePath);

        }
        public static string getBodyXml()
        {
            return docXml.ToString();
        }

        public static string getElement(string elementName)
        {
            return (string)docXml.Descendants(elementName).First();
            //return (string)docXml.Element(elementName);
            //return docXml.Element(elementName).ToString();
        }

    }
}
