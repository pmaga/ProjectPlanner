using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlannerASP5.ViewModels
{
    public class EditIssueViewModel
    {
        public int Id { get; set; }

        public int IssueNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public int EstimatedTime { get; set; }

        public ObjectStatus Status { get; private set; }
    }
}
