using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectListDto
    {
        public string Code { get; set; }
        public ProjectStatus Status { get; set; }

        public int PercentageCompleteness { get; set; }

        public DateTime CreateDate { get; set; }

        private ProjectListDto()
        {
            
        }

        public ProjectListDto(string code, ProjectStatus status, int percentageCompleteness, DateTime createDate)
        {
            Code = code;
            Status = status;
            PercentageCompleteness = percentageCompleteness;
            CreateDate = createDate;
        }
    }
}
