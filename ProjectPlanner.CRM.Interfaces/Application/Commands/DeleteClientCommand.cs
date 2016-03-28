namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class DeleteClientCommand
    {
        public string ClientCode{ get; set; }

        public DeleteClientCommand(string clientCode)
        {
            ClientCode = clientCode;
        }
    }
}