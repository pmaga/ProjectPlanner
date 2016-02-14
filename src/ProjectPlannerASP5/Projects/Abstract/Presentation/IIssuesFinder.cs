using System.Linq;

namespace ProjectPlannerASP5.Projects.Abstract.Presentation
{
    public interface IIssuesFinder
    {
        IQueryable<IssueListDto> FindIssues(string projectCode);
    }
}
