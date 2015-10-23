using ProjectPlannerASP5.ViewModels;
using System.Collections.Generic;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Services
{
    public interface IIssueService
    {
        IEnumerable<IssueView> GetIssues();
        IEnumerable<IssueView> GetIssuesByProjectCode(string projectCode);
        EditIssueViewModel GetIssue(int id);

        bool Insert(string projectCode, EditIssueViewModel issueVm);
        bool Update(EditIssueViewModel issueVm);
        bool Delete(int id);
    }
}
