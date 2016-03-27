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
                .Where(n => n.Project.Code == projectCode)
                .Select(n => new IssueListDto(n.Id, n.Status, n.IssueStateStatus, n.IssueNumber.ToString(), 
                    n.CreateTimeStamp, n.DueDate));
        }

        public IssueEditDto FindIssue(string projectCode, int issueId)
        {
            return _entityManager.CurrentSession.Query<Issue>()
                .Where(n => n.Project.Code == projectCode && n.Id == issueId)
                .Select(n => new IssueEditDto(n.Id, n.Summary, n.Description, n.CreateTimeStamp, n.LastUpdateTimeStamp,
                    n.DueDate)).FirstOrDefault();
        }
    }
}
