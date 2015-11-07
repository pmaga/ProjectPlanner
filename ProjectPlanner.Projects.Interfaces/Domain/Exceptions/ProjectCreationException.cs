using System;

namespace ProjectPlanner.Projects.Interfaces.Domain.Exceptions
{
    public class ProjectCreationException : Exception
    {
        public int UserId { get; private set; }

        public ProjectCreationException(string message, int userId)
            : base(message)
        {
            UserId = userId;
        }
    }
}