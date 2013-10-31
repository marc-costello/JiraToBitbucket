using System.Diagnostics;
using JiraToBitbucketTests.Static;
using NUnit.Framework;

namespace JiraToBitbucketTests.Models.Bitbucket
{
    [TestFixture]
    public class BitbucketDocumentTests
    {
        [Test]
        public static void ToJson_ShouldReturnSomeJson()
        {
            var converter = MockXmlData.MockJiraToBitbucketService();
            var doc = converter.BuildBitbucketDocument();

            var json = doc.ToJson();

            Debug.WriteLine(json);
        }
    }
}
