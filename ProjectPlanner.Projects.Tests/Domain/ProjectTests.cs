using ProjectPlanner.Cqrs.Base.DDD.Application;
using Xunit;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;

namespace ProjectPlanner.Projects.Tests.Domain
{
    public class ProjectTests
    {
        private readonly ProjectFactory _projectFactory;

        public ProjectTests()
        {
            var systemUser = new SystemUser();
            _projectFactory = new ProjectFactory(systemUser);
        }

        [Fact]
        public void AddUser_CannotAddIfClosed()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.Close();

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.AddUser(1);
            });
        }

        [Fact]
        public void AddUser_CanAddUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.AddUser(10);

            Assert.Equal(2, project.Users.Count);
            Assert.Contains(10, project.Users);
        }

        [Fact]
        public void AddUser_CannotAddDuplicateUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.AddUser(1);

            Assert.Equal(1, project.Users.Count);
        }

        [Fact]
        public void RemoveUser_CannotRemoveIfClosed()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.Close();

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.RemoveUser(1);
            });
        }

        [Fact]
        public void RemoveUser_CanRemoveUser()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            project.AddUser(10);
            project.RemoveUser(10);

            Assert.Equal(1, project.Users.Count);
            Assert.DoesNotContain(10, project.Users);
        }

        [Fact]
        public void RemoveUser_CannotRemoveCreator()
        {
            var project = _projectFactory.CreateProject("Code", "Name");

            Assert.Throws<ProjectOperationException>(() =>
            {
                project.RemoveUser(1);
            });
        }
    }
}
