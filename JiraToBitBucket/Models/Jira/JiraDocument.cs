using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JiraToBitBucket.Models.Jira
{
    public class JiraDocument
    {
        private XmlDocument _xml;

        public JiraDocument() {}

        public JiraDocument(XmlDocument jiraXmlDocument)
        {
            Load(jiraXmlDocument);
        }

        public IList<JiraIssue> Issues { get; private set; }
        public IList<JiraComment> Comments { get; private set; }

        public void Load(XmlDocument jiraXmlDocument)
        {
            if (_xml != null)
            {
                throw new InvalidOperationException("JiraDocument is already loaded with XML Data");
            }
            
            _xml = jiraXmlDocument;
            
            BuildIssues();
            BuildComments();
        }

        private void BuildIssues()
        {
            Issues = new List<JiraIssue>();
            var issueNodes = _xml.GetElementsByTagName("Issue");

            for (var i = 0; i < issueNodes.Count; i++)
            {
                var node = issueNodes[i];
                var jiraIssue = new JiraIssue
                {
                    IssueId = int.Parse(node.Attributes["id"].Value),
                    Summary = GetIssueSummary(node),
                    Reporter = node.Attributes["reporter"].Value,
                    Description = GetIssueDescription(node),
                    CreatedOn = DateTime.Parse(node.Attributes["created"].Value),
                    Priority = int.Parse(node.Attributes["priority"].Value),
                    Type = int.Parse(node.Attributes["type"].Value),
                    Status = int.Parse(node.Attributes["status"].Value),
                    Resolution =
                        node.Attributes.GetNamedItem("resolution") != null
                            ? int.Parse(node.Attributes["resolution"].Value)
                            : (int?) null
                };

                Issues.Add(jiraIssue);
            }
        }

        private void BuildComments()
        {
            Comments = new List<JiraComment>();
            var commentNodes = _xml.GetElementsByTagName("Action");

            for (var i = 0; i < commentNodes.Count; i++)
            {
                var node = commentNodes[i];

                if (node.Attributes["type"].Value != "comment") continue;

                var jiraComment = new JiraComment
                {
                    CommentId = int.Parse(node.Attributes["id"].Value),
                    IssueId = int.Parse(node.Attributes["issue"].Value),
                    Body = node.Attributes["body"] != null ? node.Attributes["body"].Value : node.ChildNodes[0].InnerText,
                    CreatedOn = DateTime.Parse(node.Attributes["created"].Value),
                    Author = node.Attributes["author"].Value
                };

                Comments.Add(jiraComment);
            }
        }

        private string GetIssueDescription(XmlNode issueNode)
        {
            if (issueNode.HasChildNodes && (issueNode.SelectSingleNode("description") != null))
            {
                return issueNode.ChildNodes[0].InnerText;
            } 
            else if (issueNode.Attributes.GetNamedItem("description") != null)
            {
                return issueNode.Attributes["description"].Value;
            }

            return String.Empty;
        }

        private string GetIssueSummary(XmlNode issueNode)
        {
            if (issueNode.HasChildNodes && (issueNode.SelectSingleNode("summary") != null))
            {
                return issueNode.SelectSingleNode("summary").InnerText;
            }

            return issueNode.Attributes["summary"].Value;
        }
    }
}
