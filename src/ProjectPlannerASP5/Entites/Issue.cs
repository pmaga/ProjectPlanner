using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPlannerASP5.Entites
{
    public class Issue
    {
        public int Id { get; set; }

        //[Index("IX_IssueNumber", 1, IsUnique = true)]
        public int IssueNumber { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime LastChangeDate { get; set; }

        public string Summary { get; set; }
        public string Description { get; set; }

        public IssueStatus Status { get; set; }

        public int ProjectId { get; set; }

        public string UserName { get; set; }

        //[Index("IX_IssueNumber", 2, IsUnique = true)]
        public virtual Project Project { get; set; }
    }
}
