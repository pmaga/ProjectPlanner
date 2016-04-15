using System;
using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ClientStatus Status { get; set; }
        public ClientType Type { get; set; }

        public string EmailAddress { get; set; }

        public ClientListDto(int id, string code, string name,  string emailAddress, ClientType type, ClientStatus status)
        {
            Id = id;
            Code = code;
            Name = name;
            EmailAddress = emailAddress;
            Type = type;
            Status = status;
        }
    }
}