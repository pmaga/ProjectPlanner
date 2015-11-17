using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectPlannerASP5.ViewModels
{
    public class EditProjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 3)]
        public string Code { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }
    }
}