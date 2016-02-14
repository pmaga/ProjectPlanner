using System.Linq;
using NHibernate.Linq;
using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlannerASP5.Base.Infrastructure.Orm;
using ProjectPlannerASP5.Projects.Abstract.Presentation;
using ProjectPlannerASP5.Projects.Concrete.Domain;

namespace ProjectPlannerASP5.Projects.Concrete.Presentation.Implementation
{
    [Finder]
    public class IssuesFinder : IIssuesFinder
    {
        private readonly IEntityManager _entityManager;

        public IssuesFinder(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }

        public IQueryable<IssueListDto> FindIssues(string projectCode)
        {
            return _entityManager.CurrentSession.Query<Issue>()
                .Select(n => new IssueListDto(n.Id, n.Status, n.IssueNumber.ToString(), 
                    n.CreateDate, n.DueDate));
        }
    }
}
