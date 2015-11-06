using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Domain
{
    public class Project : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public DateTime CreateDate { get; private set; }
        public ProjectStatus Status { get; private set; }

        public int CreatorUserId { get; private set; }

        public IList<Issue> Issues { get; private set; }
        public IList<int> Users { get; private set; }

        private Project()
        {
            Issues = new List<Issue>();
            Users = new List<int>();
        }

        public Project(int creatorUserId, string code, string name)
            : this()
        {
            CreatorUserId = creatorUserId;
            Code = code;
            Name = name;
            AddUser(creatorUserId);
        }

        public void AddUser(int userId)
        {
            CheckIfActive();

            if (!ContainsUser(userId))
            {
                Users.Add(userId);
            }

            // TODO: Add user event
        }

        public void RemoveUser(int userId)
        {
            CheckIfActive();

            if (IsUserCreatedProject(userId))
            {
                throw new ProjectOperationException("Cannot remove user who created a project.");
            }

            if (ContainsUser(userId))
            {
                Users.Remove(userId);
            }

            // TODO: Remove user event
        }

        public void Close()
        {
            Status = ProjectStatus.Closed;
            
            // TODO: Close event
        }

        private bool IsUserCreatedProject(int userId)
        {
            return CreatorUserId == userId;
        }

        private bool ContainsUser(int userId)
        {
            return Users.Any(user => user == userId);
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