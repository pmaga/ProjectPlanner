namespace ProjectPlanner.CRM.Interfaces.Application.Commands
{
    public class DeleteClientCommand
    {
        public int ClientId { get; set; }

        public DeleteClientCommand(int clientId)
        {
            ClientId = clientId;
        }
    }
}