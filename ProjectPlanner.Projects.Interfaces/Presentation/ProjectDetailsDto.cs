﻿using System;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Interfaces.Presentation
{
    public class ProjectDetailsDto // TODO: ValueObject
    {
        public int Id { get; private set; }
        public string CustomerName { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public int PercentageCompleteness { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; private set; } // nHibernate interceptor
        public ProjectStateStatus Status { get; private set; }

        public ProjectDetailsDto(int id, string customerName, string code,
            string name, string description,
            DateTime createDate, DateTime lastUpdate, 
            int percentageCompleteness, ObjectStatus status)
        {
            Id = id;
            CustomerName = customerName;
            Code = code;
            Name = name;
            Description = description;
            CreateDate = createDate;
            LastUpdateDate = lastUpdate;
            PercentageCompleteness = percentageCompleteness;
            Status = status == ObjectStatus.Closed ? ProjectStateStatus.Closed
                : ProjectStateStatus.Active;
        }
    }
}