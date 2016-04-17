using System;
using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public class ClientDetailsDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public string Description { get; set; }

        public ClientType Type { get; set; }
        public ClientStatus Status { get; set; }

        public DateTime CreateTimeStamp { get; set; }
        public DateTime LastUpdateTimeStamp { get; set; }
    }
}