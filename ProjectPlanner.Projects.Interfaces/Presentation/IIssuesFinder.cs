using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public interface IIssuesFinder
    {
        IQueryable<IssueListDto> FindIssues(string projectCode);
    }
}
