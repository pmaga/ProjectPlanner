using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
{
    public class ProjectCreatedEvent : IDomainEvent
    {
        public int ProjectId { get; set; }

        public ProjectCreatedEvent(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
