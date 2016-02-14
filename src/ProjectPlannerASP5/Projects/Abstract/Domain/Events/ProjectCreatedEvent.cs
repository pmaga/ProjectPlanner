using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Events
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
