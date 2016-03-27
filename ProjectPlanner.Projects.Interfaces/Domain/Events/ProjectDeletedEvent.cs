using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
{
    public class ProjectDeletedEvent : IDomainEvent
    {
        public int ProjectId { get; set; }

        public ProjectDeletedEvent(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
