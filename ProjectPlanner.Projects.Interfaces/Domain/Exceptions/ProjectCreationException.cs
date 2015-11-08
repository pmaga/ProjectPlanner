using System;

namespace ProjectPlanner.Projects.Interfaces.Domain.Exceptions
{
    public class ProjectCreationException : Exception
    {
        public Guid UserId { get; private set; }

        public ProjectCreationException(string message, Guid userId)
            : base(message)
        {
            UserId = userId;
        }
    }
}