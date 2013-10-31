using System;
using System.Xml;

namespace JiraToBitBucket.Services
{
    public class ParserService : IParser
    {
        public XmlDocument Parse(string xml)
        {
            if (String.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException("xml", "Argument cannot be null or an empty string");
            }
            
            var reader = new XmlDocument();
            reader.LoadXml(xml);

            return reader;
        }
    }
}
