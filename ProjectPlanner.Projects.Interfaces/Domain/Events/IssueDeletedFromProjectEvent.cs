using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
{
    public class IssueDeletedFromProjectEvent : IDomainEvent
    {
        public string ProjectCode { get; private set; }
        public int IssueId { get; private set; }

        public IssueDeletedFromProjectEvent(string projectCode, int issueId)
        {
            ProjectCode = projectCode;
            IssueId = issueId;
        } 
    }
}