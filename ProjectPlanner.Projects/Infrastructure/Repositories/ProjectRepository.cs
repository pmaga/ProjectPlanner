using System;
using System.Linq;
using NHibernate.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Annotations;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Infrastructure.Orm.Repositories;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Events;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;

namespace ProjectPlanner.Projects.Infrastructure.Repositories
{
    [DomainRepository]
    public class ProjectRepository : RepositoryForBaseEntity<Project>, IProjectRepository
    {
        public IDomainEventPublisher DomainEventPublisher { get; set; }

        public ProjectRepository(IEntityManager entityManager, InjectorHelper injectorHelper,
            IDomainEventPublisher domainEventPublisher)
            : base(entityManager, injectorHelper)
        {
            DomainEventPublisher = domainEventPublisher;
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

        public override void Delete(int id)
        {
            base.Delete(id);
            EntityManager.CurrentSession.Flush();

            DomainEventPublisher.Publish(new ProjectDeletedEvent(id));
        }
    }
}
