using System.Linq;

namespace ProjectPlannerASP5.Projects.Abstract.Presentation
{
    public interface IProjectFinder
    {
        IQueryable<ProjectListDto> FindProjects();
    }
}
