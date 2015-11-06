using System;
using System.Collections.Generic;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Domain
{
    public class Project : AggregateRoot
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
        public ProjectStatus Status { get; set; }

        public int CreatorUserId { get; set; }

        public IList<Issue> Issues { get; set; }
        public IList<int> Users { get; set; }

        private Project()
        {
            Issues = new List<Issue>();
            Users = new List<int>();
        }

        public Project(int creatorUserId)
            : this()
        {
            CreatorUserId = creatorUserId;
            AddUser(creatorUserId);
        }

        public void AddUser(int userId)
        {
            CheckIfActive();

            Users.Add(userId);
        }

        private void CheckIfActive()
        {
            if (Status == ProjectStatus.Closed)
            {
                throw new ProjectOperationException("Operation is not allowed in closed project");
            }
        }
    }
}