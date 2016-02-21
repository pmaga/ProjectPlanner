using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Events;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Domain
{
    public class Project : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
        public ProjectStatus Status { get; private set; } //TODO: Zmiana statusu na Modified po zapisie

        public Guid CreatorUserId { get; private set; }

        public IList<Issue> Issues { get; private set; }
        public IList<string> Users { get; private set; }

        private Project()
        {
            Issues = new List<Issue>();
            Users = new List<string>();
        }

        public Project(Guid creatorUserId, string code, string name)
            : this()
        {
            CreatorUserId = creatorUserId;
            Code = code;
            Name = name;
        }

        public void AddUser(Guid userId)
        {
            CheckIfActive();

            if (!ContainsUser(userId))
            {
                Users.Add(userId.ToString());
            }

            EventPublisher.Publish(new UserAddedToProjectEvent(userId));
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
                Users.Remove(userId.ToString());
            }

            EventPublisher.Publish(new UserRemovedFromProjectEvent(userId));
        }

        public void Close()
        {
            Status = ProjectStatus.Closed;

            EventPublisher.Publish(new ProjectClosedEvent(Id));
        }

        private bool IsUserCreatedProject(Guid userId)
        {
            return CreatorUserId == userId;
        }

        private bool ContainsUser(Guid userId)
        {
            return Users.Any(user => user == userId.ToString());
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