using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class IssueListDto
    {
        public int Id { get; private set; }

        public string FullNumber { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? DueDate { get; private set; }

        public IssueStatus Status { get; private set; }

        private IssueListDto()
        {
            
        }

        public IssueListDto(int id, IssueStatus status, string fullNumber, DateTime createDate, DateTime? dueDate)
        {
            Id = id;
            Status = status;
            FullNumber = fullNumber;
            CreateDate = createDate;
            DueDate = dueDate;
        }
    }
}
