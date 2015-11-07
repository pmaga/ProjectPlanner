using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlanner.Projects.Domain
{
    public interface IProjectRepository
    {
        Project FindByCode(string code, int userId);
    }
}
