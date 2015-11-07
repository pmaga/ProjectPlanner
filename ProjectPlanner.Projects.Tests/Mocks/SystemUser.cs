using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPlanner.Cqrs.Base.DDD.Application;

namespace ProjectPlanner.Projects.Tests.Mocks
{
    public class SystemUser : ISystemUser
    {
        public int UserId { get; private set; } = 1;

        public void SetUserId(int id)
        {
            UserId = id;
        }
    }
}
