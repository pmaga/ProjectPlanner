namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectDetailsDto // TODO: ValueObject
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }

        public ProjectDetailsDto(int id, string customerName)
        {
            Id = id;
            CustomerName = customerName;
        }
    }
}