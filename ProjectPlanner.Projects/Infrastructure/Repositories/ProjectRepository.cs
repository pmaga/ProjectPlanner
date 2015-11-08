using System;
using ProjectPlanner.Projects.Domain;

namespace ProjectPlanner.Projects.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Project FindByCode(string code, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
