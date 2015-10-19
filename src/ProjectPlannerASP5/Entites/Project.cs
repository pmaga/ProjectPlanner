﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectPlannerASP5.Entites
{
    public class Project
    {
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(5)]
        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public ProjectStatus Status { get; set; }

        //public virtual ApplicationUser Creator { get; set; }
        public string Creator { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

        public Project()
        {
            Issues = new List<Issue>();
        }
    }
}
