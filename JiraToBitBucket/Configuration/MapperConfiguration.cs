using System.Collections.Generic;

namespace JiraToBitBucket.Configuration
{
    // TODO: Get config information from a configuration file of sorts. This is only generic Jira data
    public static class MapperConfiguration
    {
        private static readonly IDictionary<string, int[]> _priority;
        private static readonly IDictionary<string, int[]> _status;
        private static readonly IDictionary<string, int[]> _type;

        static MapperConfiguration()
        {
            _priority = new Dictionary<string, int[]>
            {
                {"trivial", new []{ 5 }},
                {"minor", new []{ 4 }},
                {"major", new []{ 3 }},
                {"critical", new []{ 2 }},
                {"blocker", new []{ 1 }}
            };
            _status = new Dictionary<string, int[]>
            {
                //{"new", new []{  }},
                {"open", new []{ 1, 10000, 10001, 10006, 10011, 10012, 10013, 10014, 3, 4 }},
                {"resolved", new []{ 10002, 10010, 5, 6 }},
                {"on hold", new []{ 10005, 10007, 10008, 10009 }},
                //{"invalid", new []{ 5 }},
                {"duplicate", new []{ 10003 }},
                {"wontfix", new []{ 10004 }}
            };
            _type = new Dictionary<string, int[]>
            {
                {"bug", new []{ 1, 13, 9 }},
                {"enhancement", new []{ 11, 4 }},
                {"proposal", new []{ 10, 2 }},
                {"task", new []{ 12, 3, 5, 6, 7, 8 }}
            };
        }

        public static IDictionary<string, int[]> Priority {get { return _priority; }}
        public static IDictionary<string, int[]> Status {get { return _status; }}
        public static IDictionary<string, int[]> Type { get { return _type; }}
    }
}
