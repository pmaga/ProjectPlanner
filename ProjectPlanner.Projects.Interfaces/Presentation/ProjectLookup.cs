namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectLookup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ProjectLookup(int id, string code, string name)
        {
            Id = id;
            Code = code;
            Name = name;
        }
    }
}