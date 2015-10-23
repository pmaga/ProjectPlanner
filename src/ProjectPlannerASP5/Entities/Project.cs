using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(5)]
        [Required]
        // TODO: Ustawic jako unique
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public ProjectStatus Status { get; set; }

        public virtual AppUser Creator { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

        public Project()
        {
            Issues = new List<Issue>();
        }
    }
}
