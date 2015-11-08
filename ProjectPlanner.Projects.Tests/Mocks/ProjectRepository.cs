using System;
using ProjectPlanner.Projects.Domain;

namespace ProjectPlanner.Projects.Tests.Mocks
{
    public class ProjectRepository : IProjectRepository
    {
        public Project FindByCode(string code, Guid userId)
        {
            if (code == "code" && userId == new Guid("edf05842-e174-4777-bb48-3c21ea177be2"))
            {
                return new Project(userId, code, "name");
            }

            return null;
        }
    }
}