using NHibernate.Linq;
using ProjectPlanner.Cqrs.Base.CQRS.Query.Attributes;
using ProjectPlanner.Infrastructure.Orm;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Presentation;
using System.Linq;

namespace ProjectPlanner.Projects.Presentation.Implementation
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
                    n.CreateTimeStamp, n.DueDate));
        }
    }
}
