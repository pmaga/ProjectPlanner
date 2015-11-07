using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPlanner.Projects.Domain;

namespace ProjectPlanner.Projects.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public Project FindByCode(string code, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
