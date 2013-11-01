using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace JiraToBitBucket.Models.Bitbucket
{
    public class BitbucketIssue
    {
        [JsonProperty("id")]
        public int IssueId { get; set; }
        public string Assignee { get; set; }
        public string Content { get; set; }
        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }
        [JsonProperty("content_updated_on")]
        public string ContentUpdatedOn { get; set; }
        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }
        public string Kind { get; set; }
        public string Reporter { get; set;}
        public string Priority { get; set; }
        public string Status { get; set; }
        [StringLength(255)]
        public string Title { get; set; }

        // Null by manditory properties
        public string Component { get; set; }
        [JsonProperty("edited_on")]
        public string EditedOn { get; set; }
        public string Milestone { get; set; }
        public string Version { get; set; }
        public string[] Watchers { get; set; }
        public string[] Voters { get; set; }
    }
}
