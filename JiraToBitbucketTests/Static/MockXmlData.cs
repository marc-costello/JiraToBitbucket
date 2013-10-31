using JiraToBitBucket.Models.Jira;
using JiraToBitBucket.Services;

namespace JiraToBitbucketTests.Static
{
    public static class MockXmlData
    {
        public static string Action = "<Action id=\"10114\" issue=\"10218\" author=\"richard.dowson\" type=\"comment\" body=\"Update applied. Miscellaneous fixes outstanding.\" created=\"2011-08-05 00:08:26.167\" updateauthor=\"richard.dowson\" updated=\"2011-08-05 00:08:26.167\"/>";
        public static string IssueWithDescriptionAttr = "<Issue id=\"10020\" key=\"FSP-1\" project=\"10010\" reporter=\"richard.dowson\" assignee=\"richard.dowson\" type=\"7\" summary=\"When the application loads, users should be automatically authenticated using the current Windows user. The signed in user should be indicated on page.\" description=\"When the application loads, users should be automatically authenticated using the current Windows user. The signed in user should be indicated on page.\" priority=\"3\" resolution=\"1\" status=\"6\" created=\"2011-01-31 15:37:31.137\" updated=\"2011-03-24 10:07:46.577\" resolutiondate=\"2011-03-16 11:46:04.23\" votes=\"0\" watches=\"0\" timeoriginalestimate=\"57600\" timeestimate=\"0\" timespent=\"86400\" workflowId=\"10020\"/>";

        public static JiraToBitbucketService MockJiraToBitbucketService()
        {
            var loader =
                new FileLoaderService(
                    "C:/Users/marc.costello/Documents/Visual Studio 2012/Projects/JiraToBitBucket/jira_export.xml");
            loader.LoadFile();
            var xmlDocument = new ParserService().Parse(loader.XmlData);
            var document = new JiraDocument(xmlDocument);
            return new JiraToBitbucketService(document);
        }
    }
}
