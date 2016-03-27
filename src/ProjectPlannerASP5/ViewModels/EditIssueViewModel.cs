using Microsoft.AspNet.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using ProjectPlanner.Projects.Domain.Interfaces;

namespace ProjectPlannerASP5.ViewModels
{
    public class EditIssueViewModel
    {
        public int Id { get; set; }

        public int IssueNumber { get; set; }

        public DateTime? DueDate { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }

        public int EstimatedTime { get; set; }

        public IssueStatus Status { get; private set; }
    }
}
