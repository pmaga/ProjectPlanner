using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class IssueListDto
    {
        public int Id { get; private set; }

        public string FullNumber { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public ObjectStatus Status { get; private set; }

        private IssueListDto()
        {
            
        }

        public IssueListDto(int id, ObjectStatus status, string fullNumber, DateTime createDate, DateTime? dueDate)
        {
            Id = id;
            Status = status;
            FullNumber = fullNumber;
            CreateDate = createDate;
            DueDate = dueDate;
        }
    }
}
