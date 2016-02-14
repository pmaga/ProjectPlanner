using System;

namespace ProjectPlannerASP5.Projects.Abstract.Domain.Exceptions
{
    public class ProjectOperationException : Exception
    {
        public ProjectOperationException(string message)
            : base(message)
        {

        }
    }
}