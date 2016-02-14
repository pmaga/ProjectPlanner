using System.Linq;
using NHibernate.Linq;
using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlannerASP5.Base.Infrastructure.Orm;
using ProjectPlannerASP5.Projects.Abstract.Presentation;
using ProjectPlannerASP5.Projects.Concrete.Domain;

namespace ProjectPlannerASP5.Projects.Concrete.Presentation.Implementation
{
    [Finder]
    public class ProjectFinder : IProjectFinder
    {
        private readonly IEntityManager _entityManager;

        public ProjectFinder(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public IQueryable<ProjectListDto> FindProjects()
        {
            return _entityManager.CurrentSession.Query<Project>() //TODO: Pozbyc sie referencji do NHibernate?
                .Select(n => new ProjectListDto(n.Id, n.Code, n.Name, n.Status, 0, n.CreateDate));
        }
    }
}
