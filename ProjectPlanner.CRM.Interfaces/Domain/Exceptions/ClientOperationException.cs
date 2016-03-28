using System;

namespace ProjectPlanner.CRM.Interfaces.Domain.Exceptions
{
    public class ClientOperationException : Exception
    {
        public ClientOperationException(string message)
            : base(message)
        {
            
        }
    }
}