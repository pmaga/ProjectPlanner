using ProjectPlanner.Projects.Domain.Interfaces;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectDetailsDto // TODO: ValueObject
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public string ProjectCode { get; private set; }
        public string ProjectName { get; private set; }
        public ProjectStateStatus Status{ get; private set; }

        public ProjectDetailsDto(int id, string customerName, string code,
            string name, ProjectStatus status)
        {
            Id = id;
            CustomerName = customerName;
            ProjectCode = code;
            ProjectName = name;
            Status = status == ProjectStatus.Closed ? ProjectStateStatus.Closed
                : ProjectStateStatus.Active;
        }
    }
}