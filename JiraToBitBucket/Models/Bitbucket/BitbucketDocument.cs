using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JiraToBitBucket.Models.Bitbucket
{
    public class BitbucketDocument
    {
        public BitbucketDocument()
        {
            Issues = new List<BitbucketIssue>();
            Comments = new List<BitbucketComment>();
        }

        public IList<BitbucketIssue> Issues { get; set; }
        public IList<BitbucketComment> Comments { get; set; }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(this, settings);
        } 
    }
}
