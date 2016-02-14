using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Events
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