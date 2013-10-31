using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models.Jira
{
    public class JiraComment
    {
        public int CommentId { get; set; }
        public int IssueId { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
