using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public class ClientListDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ClientStatus Status { get; set; }
    }
}