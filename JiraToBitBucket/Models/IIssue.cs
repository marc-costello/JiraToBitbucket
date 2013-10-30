using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models
{
    public interface IIssue
    {
        int IssueId { get; }
        string Content { get; }
        DateTime CreatedOn { get; }
        string Kind { get; }
        string Title { get; }
        string Priority { get; }
        string Status { get; }
    }
}
