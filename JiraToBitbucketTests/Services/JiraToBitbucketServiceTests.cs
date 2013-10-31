using JiraToBitBucket.Models.Bitbucket;
using JiraToBitBucket.Models.Jira;
using JiraToBitBucket.Services;
using NUnit.Framework;
using Shouldly;

namespace JiraToBitbucketTests.Services
{
    [TestFixture]
    public class JiraToBitbucketServiceTests
    {
        private static JiraDocument getJiraDocument()
        {
            var xml = new FileLoaderService("C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.xml")
                .LoadFile()
                .XmlData;
            var parser = new ParserService().Parse(xml);
            return new JiraDocument(parser);
        }

        [Test]
        public static void BuildBitbucketModel_ShouldPopulateAndReturnAFullBitbucketDocumentModel()
        {
            var service = new JiraToBitbucketService(getJiraDocument());
            var bitbucketDocument = service.BuildBitbucketDocument();

            bitbucketDocument.ShouldBeTypeOf<BitbucketDocument>();
            bitbucketDocument.Issues.ShouldNotBeEmpty();
            bitbucketDocument.Comments.ShouldNotBeEmpty();
        }
    }
}
