using Microsoft.AspNet.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using ProjectPlanner.Projects.Domain.Interfaces;

namespace ProjectPlannerASP5.ViewModels
{
    public class EditIssueViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IssueNumber { get; set; }

        [Display(Name = "Create date")]
        //[ReadOnly(true)]
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;

        [Display(Name = "Due date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DueDate { get; set; }
        public DateTime? LastChangeDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(255, MinimumLength = 5)]
        public string Summary { get; set; }

        public string Description { get; set; }

        //public ApplicationUser Reporter { get; set; }

        public int EstimatedTime { get; set; }

        public IssueStatus Status { get; private set; }
    }
}
