using System.Linq;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public interface IProjectFinder
    {
        IQueryable<ProjectListDto> FindProjects();
        ProjectDetailsDto FindProject(int projectId);
    }
}
