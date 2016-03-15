using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class CreateProjectCommand
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        [OutputCommandParameter]
        public int ProjectId { get; set; }

        public CreateProjectCommand(string code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }
    }
}
