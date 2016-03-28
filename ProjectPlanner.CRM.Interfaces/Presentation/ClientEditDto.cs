using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public class ClientEditDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public ClientStatus Status { get; set; }
    }
}