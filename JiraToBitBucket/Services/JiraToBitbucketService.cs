using System.Globalization;
using System.Linq;
using JiraToBitBucket.Configuration;
using JiraToBitBucket.Models.Bitbucket;
using JiraToBitBucket.Models.Jira;

namespace JiraToBitBucket.Services
{
    public class JiraToBitbucketService
    {
        private readonly JiraDocument _jiraDocument;
        private readonly BitbucketDocument _bitbucketDocument = new BitbucketDocument();

        public JiraToBitbucketService(JiraDocument jiraDocument)
        {
            _jiraDocument = jiraDocument;
        }

        public BitbucketDocument BuildBitbucketDocument()
        {
            // Issues
            foreach (var jiraIssue in _jiraDocument.Issues)
            {
                var bitBucketIssue = new BitbucketIssue();

                bitBucketIssue.IssueId = jiraIssue.IssueId;
                bitBucketIssue.Title = jiraIssue.Summary;
                bitBucketIssue.Assignee = jiraIssue.Reporter;
                bitBucketIssue.Reporter = jiraIssue.Reporter;
                bitBucketIssue.Content = jiraIssue.Description;
                bitBucketIssue.CreatedOn = jiraIssue.CreatedOn.ToString("s", CultureInfo.InvariantCulture);
                bitBucketIssue.ContentUpdatedOn = jiraIssue.CreatedOn.ToString("s", CultureInfo.InvariantCulture);
                bitBucketIssue.UpdatedOn = jiraIssue.CreatedOn.ToString("s", CultureInfo.InvariantCulture);
                bitBucketIssue.Kind = MapperConfiguration.Type.Single(k => k.Value.Contains(jiraIssue.Type)).Key ?? "bug";
                bitBucketIssue.Priority = MapperConfiguration.Priority.Single(k => k.Value.Contains(jiraIssue.Priority)).Key;
                bitBucketIssue.Status = MapperConfiguration.Status.Single(k => k.Value.Contains(jiraIssue.Status)).Key;

                _bitbucketDocument.Issues.Add(bitBucketIssue);
            }

            // Comments
            foreach (var jiraComment in _jiraDocument.Comments)
            {
                var bitBucketComment = new BitbucketComment()
                {
                    CommentId = jiraComment.CommentId,
                    IssueId = jiraComment.IssueId,
                    CreatedOn = jiraComment.CreatedOn.ToString("s", CultureInfo.InvariantCulture),
                    User = jiraComment.Author,
                    Content = jiraComment.Body
                };

                _bitbucketDocument.Comments.Add(bitBucketComment);
            }
            
            return _bitbucketDocument;
        }
    }
}
