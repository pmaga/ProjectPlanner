using ProjectPlanner.Projects.Domain;

namespace ProjectPlanner.Projects.Tests.Mocks
{
    public class ProjectRepository : IProjectRepository
    {
        public Project FindByCode(string code, int userId)
        {
            if (code == "code" && userId == 1)
            {
                return new Project(userId, code, "name");
            }

            return null;
        }
    }
}