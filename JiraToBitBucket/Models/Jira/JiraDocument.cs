using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models.Jira
{
    public class JiraDocument : IDocument
    {
        public IEnumerable<IIssue> Issues { get; private set; }
        public IEnumerable<IComment> Comments { get; private set; }
    }
}
