using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlannerASP5.ViewModels
{
    public class EditClientViewModel
    {
        public ClientType Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    }
}