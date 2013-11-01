using System.Diagnostics;
using JiraToBitbucketTests.Static;
using NUnit.Framework;
using Shouldly;

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

            json.ShouldNotBeEmpty();
        }
    }
}
