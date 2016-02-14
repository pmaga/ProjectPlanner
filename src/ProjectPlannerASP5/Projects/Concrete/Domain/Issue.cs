using System;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;
using ProjectPlannerASP5.Projects.Abstract.Domain;

namespace ProjectPlannerASP5.Projects.Concrete.Domain
{
    public class Issue : AggregateRoot
    {
        public int IssueNumber { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime LastChangeDate { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        public IssueStatus Status { get; set; }

        public string UserName { get; set; }
    }
}
