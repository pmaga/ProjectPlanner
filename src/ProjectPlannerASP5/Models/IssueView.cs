using System;
using ProjectPlanner.Projects.Domain;

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

        public IssueStatus Status { get; set; }

        public string Reporter { get; set; }
    }
}
