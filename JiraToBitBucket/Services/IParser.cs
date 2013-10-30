using System.Xml;

namespace JiraToBitBucket.Services
{
    public interface IParser
    {
        XmlDocument Parse(string xml);
    }
}
