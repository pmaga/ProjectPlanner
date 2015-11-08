using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Domain
{
    public class Project : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public DateTime CreateDate { get; private set; }
        public ProjectStatus Status { get; private set; } //TODO: Zmiana statusu na Modified po zapisie

        public Guid CreatorUserId { get; private set; }

        public IList<Issue> Issues { get; private set; }
        public IList<Guid> Users { get; private set; }

        private Project()
        {
            CreateDate = DateTime.UtcNow;

            Issues = new List<Issue>();
            Users = new List<Guid>();
        }

        public Project(Guid creatorUserId, string code, string name)
            : this()
        {
            CreatorUserId = creatorUserId;
            Code = code;
            Name = name;
            AddUser(creatorUserId);
        }

        public void AddUser(Guid userId)
        {
            CheckIfActive();

            if (!ContainsUser(userId))
            {
                Users.Add(userId);
            }

            // TODO: Add user event
        }

        public void RemoveUser(Guid userId)
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

        private bool IsUserCreatedProject(Guid userId)
        {
            return CreatorUserId == userId;
        }

        private bool ContainsUser(Guid userId)
        {
            return Users.Any(user => user == userId);
        }

        private void CheckIfActive()
        {
            if (Status == ProjectStatus.Closed)
            {
                throw new ProjectOperationException("Operation is not allowed in closed project.");
            }
        }
    }
}