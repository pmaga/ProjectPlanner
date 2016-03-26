using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class DeleteProjectCommand
    {
        public int ProjectId { get; }

        public DeleteProjectCommand(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
