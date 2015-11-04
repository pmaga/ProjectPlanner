using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPlanner.Cqrs.Base.CQRS.Commands.Handler;
using ProjectPlanner.Cqrs.Base.Infrastructure.Attributes;

namespace ProjectPlanner.Cqrs.Base.CQRS.Commands
{
    [Component]
    public class RunEnvironment
    {
        public ICommandHandlerFactory Factory { get; set; }

        public void Run<T>(T command)
        {
            // Transaction/Commit/Container CommandHandler decorators are loaded by default
            ICommandHandler<T> handler = Factory.Create<T>();

            //place do DI, security, transaction management, logging, profilling, etc

            handler.Handle(command);
        }

    }
}
