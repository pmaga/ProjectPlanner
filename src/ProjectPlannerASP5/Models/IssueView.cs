using System;
using ProjectPlannerASP5.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProjectPlannerASP5.Models
{
    public class IssueView
    {
        public int Id { get; set; }

        public string IssueFullNumber { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? DueDate { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public IssueStatus Status { get; set; }

        public string Reporter { get; set; }
    }
}
