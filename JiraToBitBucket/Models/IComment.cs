using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraToBitBucket.Models
{
    public interface IComment
    {
        string Content { get; }
        DateTime CreatedOn { get; }
        int Issue { get; }
        string User { get; }
    }
}
