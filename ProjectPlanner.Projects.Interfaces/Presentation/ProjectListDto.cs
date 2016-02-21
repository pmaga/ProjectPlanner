using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectListDto
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ProjectStatus Status { get; set; }

        public int PercentageCompleteness { get; set; }

        public DateTime CreateDate { get; set; }

        private ProjectListDto()
        {
            
        }

        public ProjectListDto(int id, string code, string name, 
            ProjectStatus status, int percentageCompleteness, DateTime createDate)
        {
            Id = id;
            Code = code;
            Name = name;
            Status = status;
            PercentageCompleteness = percentageCompleteness;
            CreateDate = createDate;
        }
    }
}
