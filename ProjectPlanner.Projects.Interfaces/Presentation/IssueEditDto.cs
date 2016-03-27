using System;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class IssueEditDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public DateTime CreateTimeStamp { get; set; }
        public DateTime LastUpdateTimeStamp { get; set; }
        public DateTime? DueDate { get; set; }

        public IssueEditDto(int id, string summary, string description, DateTime createTimeStamp,
            DateTime lastUpdateTimeStamp, DateTime? dueDate)
        {
            Id = id;
            Summary = summary;
            Description = description;
            CreateTimeStamp = createTimeStamp;
            LastUpdateTimeStamp = lastUpdateTimeStamp;
            DueDate = dueDate;
        }
    }
}