using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models.Jira
{
    public class JiraIssue
    {
        public JiraIssue() {}

        public int IssueId { get; set; }
        public string Reporter { get; set; }
        public int Type { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? Resolution { get; set; }
    }
}
