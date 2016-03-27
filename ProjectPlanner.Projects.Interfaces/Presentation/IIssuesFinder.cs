using System.Linq;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public interface IIssuesFinder
    {
        IQueryable<IssueListDto> FindIssues(string projectCode);
        IssueEditDto FindIssue(string projectCode, int issueId);
    }
}
