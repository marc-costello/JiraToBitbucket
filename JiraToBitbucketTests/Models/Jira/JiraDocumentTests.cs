using System;
using System.Linq;
using System.Xml;
using JiraToBitBucket.Models.Jira;
using JiraToBitBucket.Services;
using NUnit.Framework;
using Shouldly;

namespace JiraToBitbucketTests.Models.Jira
{
    [TestFixture]
    public class JiraDocumentTests
    {
        private static XmlDocument getXmlDocument()
        {
            var loader =
                new FileLoaderService(
                    "C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.xml");
            loader.LoadFile();
            return new ParserService().Parse(loader.XmlData);
        }
        
        [Test]
        public static void LoadIssues_ShouldPopulateIssuesCollectionWithNewJiraIssues()
        {            
            var document = new JiraDocument(getXmlDocument());

            document.Issues.ShouldNotBeEmpty();
            document.Issues.First().IssueId.ShouldBeGreaterThan(0);
            document.Issues.First().Summary.ShouldNotBeEmpty();
        }

        [Test]
        public static void LoadComments_ShouldPopulateIssuesCollectionWithNewJiraComments()
        {
            var document = new JiraDocument(getXmlDocument());

            document.Comments.ShouldNotBeEmpty();
            document.Comments.First().CommentId.ShouldBeGreaterThan(0);
            document.Comments.First().Body.ShouldNotBeEmpty();
        }

        [Test]
        public static void Load_ShouldTthrowIfLoadHasAlreadyBeenCalled()
        {
            var document = new JiraDocument(getXmlDocument());

            Should.Throw<InvalidOperationException>(() => document.Load(getXmlDocument()));
        }
    }
}
