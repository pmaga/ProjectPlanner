using ProjectPlanner.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlanner.Projects.Interfaces.Application.Commands
{
    public class CreateProjectCommand
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        [OutputCommandParameter]
        public int ProjectId { get; set; }

        public CreateProjectCommand(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
