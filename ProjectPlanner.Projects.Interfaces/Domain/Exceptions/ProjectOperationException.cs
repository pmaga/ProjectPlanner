using System;

namespace ProjectPlanner.Projects.Interfaces.Domain.Exceptions
{
    public class ProjectOperationException : Exception
    {
        public ProjectOperationException(string message)
            : base(message)
        {

        }
    }
}