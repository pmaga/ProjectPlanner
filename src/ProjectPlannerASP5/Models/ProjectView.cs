﻿using System;

namespace ProjectPlannerASP5.Entites
{
    public class ProjectView
    {
        public string Code { get; set; }
        public ProjectStatus Status { get; set; }

        public int PercentageCompleteness { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
