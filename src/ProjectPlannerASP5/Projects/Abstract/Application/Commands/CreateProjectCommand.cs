using ProjectPlannerASP5.Base.Cqrs.Base.CQRS.Commands.Attributes;

namespace ProjectPlannerASP5.Projects.Abstract.Application.Commands
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
