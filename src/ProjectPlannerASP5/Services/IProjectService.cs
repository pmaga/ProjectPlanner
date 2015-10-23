using ProjectPlannerASP5.Entites;
using ProjectPlannerASP5.ViewModels;
using System.Collections.Generic;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Services
{
    public interface IProjectService
    {
        List<ProjectView> GetProjects();

        EditProjectViewModel GetProject(int id);

        bool Insert(EditProjectViewModel projectVm);
        bool Update(EditProjectViewModel projectVm);
        bool Delete(int id);
    }
}