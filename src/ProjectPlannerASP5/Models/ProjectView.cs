using System;
using ProjectPlannerASP5.Entities;

namespace ProjectPlannerASP5.Models
{
    public class ProjectView
    {
        public string Code { get; set; }
        public ProjectStatus Status { get; set; }

        public int PercentageCompleteness { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
