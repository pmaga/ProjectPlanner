using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class CreateClientCommand
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        [OutputCommandParameter]
        public int ClientId { get; set; }

        public CreateClientCommand(string code, string name, string phone, string emailAddress)
        {
            Code = code;
            Name = name;
            Phone = phone;
            EmailAddress = emailAddress;
        }
    }
}