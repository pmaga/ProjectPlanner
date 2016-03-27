using System;
using System.Collections.Generic;
using System.Linq;
using ProjectPlanner.Cqrs.Base.DDD.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Events;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;
using ProjectPlanner.Projects.Interfaces.Domain;

namespace ProjectPlanner.Projects.Domain
{
    public class Project : AggregateRoot
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public DateTime CreateTimeStamp { get; private set; } // nHibernate interceptor
        public DateTime LastUpdateTimeStamp { get; private set; } // nHibernate interceptor
        public ObjectStatus Status { get; private set; }

        public Guid CreatorUserId { get; private set; }

        public IList<Issue> Issues { get; private set; }
        public IList<string> Users { get; private set; }

        private Project()
        {
            Issues = new List<Issue>();
            Users = new List<string>();
        }

        public Project(Guid creatorUserId, string code, string name)
            : this(creatorUserId, code, name, null)
        {
        }

        public Project(Guid creatorUserId, string code, string name, string description)
            : this()
        {
            CreatorUserId = creatorUserId;
            Code = code;
            Name = name;
            Description = description;
        }

        public void ChangeProjectInformation(string code, string name, string description)
        {
            if (!Code.Equals(code))
            {
                Code = code;
            }
            if (!Name.Equals(name))
            {
                Name = name;
            }
            if (Description != null && !Description.Equals(description))
            {
                Description = description;
            }
        }

        public void SetDescription(string description)
        {
            if (Description != null && Description.Equals(description))
            {
                return;
            }

            Description = description;
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
            Status = ObjectStatus.Closed;

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
            if (Status == ObjectStatus.Closed)
            {
                throw new ProjectOperationException("Operation is not allowed in closed project.");
            }
        }

        public void AddIssue(string summary, string description, DateTime? dueDate)
        {
            CheckIfActive();

            Issues.Add(new Issue(summary, description, dueDate));

            EventPublisher.Publish(new IssueAddedToProjectEvent());
        }

        public void DeleteIssue(int issueId)
        {
            CheckIfActive();

            var issue = Issues.FirstOrDefault(n => n.Id == issueId);
            if (issue == null)
            {
                throw new ProjectOperationException("Specified issue does not exist.");
            }

            Issues.Remove(issue);

            EventPublisher.Publish(new IssueDeletedFromProjectEvent(Code, issueId));
        }
    }
}