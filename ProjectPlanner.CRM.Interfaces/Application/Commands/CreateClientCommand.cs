using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;
using ProjectPlanner.CRM.Interfaces.Domain;

namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class CreateClientCommand
    {
        public ClientType Type { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string EmailAddress { get; set; }

        [OutputCommandParameter]
        public int ClientId { get; set; }

        public CreateClientCommand(ClientType type, string code, string name, string phone, string emailAddress)
        {
            Type = type;
            Code = code;
            Name = name;
            Phone = phone;
            EmailAddress = emailAddress;
        }
    }
}