using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectEditDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime CreateTimeStamp { get; set; }
        public DateTime LastUpdateTimeStamp { get; set; }
        public ObjectStatus Status { get; set; }
    }
}
