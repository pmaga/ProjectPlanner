using System;
using System.Linq;
using NHibernate.Linq;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain;
using ProjectPlannerASP5.Base.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlannerASP5.Base.Infrastructure.Orm;
using ProjectPlannerASP5.Base.Infrastructure.Orm.Repositories;
using ProjectPlannerASP5.Projects.Abstract.Domain.Events;
using ProjectPlannerASP5.Projects.Concrete.Domain;

namespace ProjectPlannerASP5.Projects.Concrete.Infrastructure.Repositories
{
    [DomainRepository]
    public class ProjectRepository : RepositoryForBaseEntity<Project>, IProjectRepository
    {
        public IDomainEventPublisher DomainEventPublisher { get; set; }

        public ProjectRepository(IEntityManager entityManager)
            : base(entityManager)
        {
        }

        public Project FindByCode(string code, Guid userId)
        {
            return EntityManager.CurrentSession.Query<Project>()
                .FirstOrDefault(p => p.Code == code);
        }

        public override void Save(Project project)
        {
            var isNewEntity = project.Id == 0;

            base.Save(project);

            if (isNewEntity)
            {
                DomainEventPublisher.Publish(new ProjectCreatedEvent(project.Id));
            }
        }
    }
}
