using System;
using System.Xml;
using JiraToBitBucket.Services;
using NUnit.Framework;
using Shouldly;

namespace JiraToBitbucketTests.Services
{
    [TestFixture]
    public class ParserServiceTests
    {
        [Test]
        public static void Parse_ThrowsAnArgumentExceptionIfStringIsEmptyOrNull()
        {
            Should.Throw<ArgumentNullException>(() => new ParserService().Parse(String.Empty));
        }
        
        [Test]
        public static void Parse_ThrowsXmlExceptionIfParseFails()
        {
            var parser = new ParserService();

            Should.Throw<XmlException>(() => parser.Parse("Not an XML string"));
        }
    }
}
