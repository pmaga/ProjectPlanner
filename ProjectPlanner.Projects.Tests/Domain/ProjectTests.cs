using System;
using Xunit;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;
using ProjectPlanner.Projects.Tests.Mocks;

namespace ProjectPlanner.Projects.Tests.Domain
{
    public class ProjectTests
    {
        private readonly Guid _defaultUserId = new Guid("edf05842-e174-4777-bb48-3c21ea177be2");
        private readonly ProjectFactory _projectFactory;

        public ProjectTests()
        {
            var systemUser = new SystemUser();
            var projectRepository = new ProjectRepository();

            _projectFactory = new ProjectFactory(systemUser, projectRepository);
        }

        [Fact]
        public void AddUser_CannotAddIfClosed()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.Close();

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.AddUser(_defaultUserId);
            });
        }

        [Fact]
        public void AddUser_CanAddUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");
            var userId = new Guid();
            project.AddUser(userId);

            Assert.Equal(2, project.Users.Count);
            Assert.Contains(userId.ToString(), project.Users);
        }

        [Fact]
        public void AddUser_CannotAddDuplicateUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.AddUser(_defaultUserId);

            Assert.Equal(1, project.Users.Count);
        }

        [Fact]
        public void RemoveUser_CannotRemoveIfClosed()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.Close();

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.RemoveUser(_defaultUserId);
            });
        }

        [Fact]
        public void RemoveUser_CanRemoveUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");
            var userId = new Guid();
            project.AddUser(userId);
            project.RemoveUser(userId);

            Assert.Equal(1, project.Users.Count);
            Assert.DoesNotContain(userId.ToString(), project.Users);
        }

        [Fact]
        public void RemoveUser_CannotRemoveCreator()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.RemoveUser(_defaultUserId);
            });
        }
    }
}
