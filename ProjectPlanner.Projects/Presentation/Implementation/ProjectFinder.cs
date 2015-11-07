using System.Linq;
using ProjectPlanner.Projects.Interfaces.Presentation;

namespace ProjectPlanner.Projects.Presentation.Implementation
{
    public class ProjectFinder : IProjectFinder
    {
        public IQueryable<ProjectListDto> FindProjects()
        {
            return null;
        }
    }
}
