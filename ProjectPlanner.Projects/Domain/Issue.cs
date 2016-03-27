using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Domain
{
    public class Issue : Entity
    {
        public int IssueNumber { get; set; }

        public DateTime CreateTimeStamp { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime LastUpdateTimeStamp { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public ObjectStatus Status { get; set; }

        public string UserName { get; set; }

        public Project Project { get; set; }

        private Issue()
        {
            
        }

        public Issue(string summary, string description, DateTime? dueDate)
        {
            Summary = summary;
            Description = description;
            DueDate = dueDate;
        }
    }
}
