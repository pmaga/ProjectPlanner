using ProjectPlanner.Cqrs.Base.DDD.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlanner.Projects.Domain
{
    public class ProjectFactory
    {
        private readonly ISystemUser _user;

        public ProjectFactory(ISystemUser user)
        {
            _user = user;
        }

        public Project CreateProject(string code, string name)
        {
            return new Project(_user.UserId, code, name);
        }
    }
}
