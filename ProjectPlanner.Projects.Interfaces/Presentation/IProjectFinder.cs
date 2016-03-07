using System.Linq;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public interface IProjectFinder
    {
        IQueryable<ProjectListDto> FindProjects();
        ProjectDetailsDto GetProjectDetails(int projectId);
        ProjectEditDto GetProject(int projectId);
    }
}
