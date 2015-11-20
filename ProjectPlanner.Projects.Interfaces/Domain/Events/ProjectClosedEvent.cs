using ProjectPlanner.Cqrs.Base.DDD.Domain;

namespace ProjectPlanner.Projects.Interfaces.Domain.Events
{
    public class ProjectClosedEvent : IDomainEvent
    {
        public int ProjectId { get; set; }

        public ProjectClosedEvent(int projectId)
        {
            ProjectId = projectId;
        }
    }
}