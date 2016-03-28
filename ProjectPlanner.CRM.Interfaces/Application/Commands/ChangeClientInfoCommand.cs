namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class ChangeClientInfoCommand
    {
        public string ClientCode { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        public ChangeClientInfoCommand(string code, string name, string phone, string emailAddress)
        {
            ClientCode = code;
            Name = name;
            Phone = phone;
            EmailAddress = emailAddress;
        }
    }
}