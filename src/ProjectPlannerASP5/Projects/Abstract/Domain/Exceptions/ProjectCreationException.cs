using System;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Exceptions
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