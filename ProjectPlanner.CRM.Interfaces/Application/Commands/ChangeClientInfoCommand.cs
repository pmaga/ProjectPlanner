namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class ChangeClientInfoCommand
    {
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public ChangeClientInfoCommand(string name, string phone, string emailAddress)
        {
            Name = name;
            Phone = phone;
            EmailAddress = emailAddress;
        }
    }
}