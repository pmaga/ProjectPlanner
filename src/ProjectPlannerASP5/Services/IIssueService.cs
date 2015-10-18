using ProjectPlannerASP5.Models;
using ProjectPlannerASP5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Services
{
    public interface IIssueService
    {
        IEnumerable<IssueView> GetIssues();
        EditIssueViewModel GetIssue(int id);

        void Insert(EditIssueViewModel issueVm);
        void Update(EditIssueViewModel issueVm);
        void Delete(int id);
    }
}
