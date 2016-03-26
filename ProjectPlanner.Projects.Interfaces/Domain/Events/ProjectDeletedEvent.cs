using ProjectPlanner.Cqrs.Base.DDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
