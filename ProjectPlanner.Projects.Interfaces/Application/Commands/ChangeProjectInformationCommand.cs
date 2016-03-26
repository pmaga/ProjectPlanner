namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class ChangeProjectInformationCommand
    {
        public int ProjectId { get; set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ChangeProjectInformationCommand(int projectId, string code, string name, string description)
        {
            ProjectId = projectId;
            Code = code;
            Name = name;
            Description = description;
        }
    }
}