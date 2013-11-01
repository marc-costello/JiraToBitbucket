using Newtonsoft.Json;

namespace JiraToBitBucket.Models.Bitbucket
{
    public class BitbucketComment
    {
        [JsonProperty("id")]
        public int CommentId { get; set; }
        [JsonProperty("issue")]
        public int IssueId { get; set; }
        public string User { get; set; }
        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }
        public string Content { get; set; }
        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }
    }
}
