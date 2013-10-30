using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models
{
    public interface IDocument
    {
        IEnumerable<IIssue> Issues { get; }
        IEnumerable<IComment> Comments { get; } 
    }
}
