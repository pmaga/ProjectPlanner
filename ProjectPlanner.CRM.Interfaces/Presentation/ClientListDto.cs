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

        public DateTime CreateTimeStamp { get; set; }
        public DateTime LastUpdateTimeStamp { get; set; }

        public ClientListDto(int id, string code, string name, ClientStatus status)
        {
            Id = id;
            Code = code;
            Name = name;
            Status = status;
        }
    }
}