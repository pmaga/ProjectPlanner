namespace ProjectPlanner.CRM.Interfaces.Presentation
{
    public class ClientLookup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ClientLookup(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
    }
}