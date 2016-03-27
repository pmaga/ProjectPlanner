using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class IssueListDto
    {
        public int Id { get; private set; }

        public string FullNumber { get; private set; }
        public string Summary { get; set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public ObjectStatus Status { get; private set; }
        public IssueStateStatus IssueStatus { get; set; }

        private IssueListDto()
        {
            
        }

        public IssueListDto(int id, ObjectStatus status, IssueStateStatus issueStatus,
            string fullNumber,  string summary, DateTime createDate, DateTime? dueDate)
        {
            Id = id;
            Status = status;
            IssueStatus = issueStatus;
            FullNumber = fullNumber;
            Summary = summary;
            CreateDate = createDate;
            DueDate = dueDate;
        }
    }
}
