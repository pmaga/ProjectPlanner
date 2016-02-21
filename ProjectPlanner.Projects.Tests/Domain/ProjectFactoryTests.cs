using System;
using ProjectPlanner.Cqrs.Base.DDD.Domain.Helpers;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;
using ProjectPlanner.Projects.Tests.Mocks;
using ProjectPlanner.Tests.Helpers;
using Xunit;

namespace ProjectPlanner.Projects.Tests.Domain
{
    public class ProjectFactoryTests
    {
        private readonly Guid _defaultUserId = new Guid("edf05842-e174-4777-bb48-3c21ea177be2");
        private ProjectFactory _projectFactory;

        public ProjectFactoryTests()
        {
            var systemUser = new SystemUser();
            var projectRepository = new ProjectRepository();
            var injectorHelper = new TestInjectorHelper();

            _projectFactory = new ProjectFactory(systemUser, projectRepository, injectorHelper);
        }

        [Fact]
        public void CreateProject_CanCreateProject()
        {
            var project = _projectFactory.CreateProject("projectCode", "projectName");

            Assert.NotNull(project);
            Assert.Equal(_defaultUserId, project.CreatorUserId);
            Assert.Equal("projectCode", project.Code);
            Assert.Equal("projectName", project.Name);
        }

        [Fact]
        public void CreateProject_CannotAddProjectWithExistingCodeForTheSameUser()
        {
            Assert.Throws<ProjectCreationException>(() =>
            {
                _projectFactory.CreateProject("code", "projectName");
            });
        }

        [Fact]
        public void CreateProject_CanCreateProjectWithExistingCodeForOtherUser()
        {
            var systemUser = new SystemUser();
            var newId = new Guid();
            systemUser.SetUserId(newId);
            var projectRepository = new ProjectRepository();
            var injectorHelper = new TestInjectorHelper();
            _projectFactory = new ProjectFactory(systemUser, projectRepository, injectorHelper);

            var project = _projectFactory.CreateProject("code", "projectName");

            Assert.NotNull(project);
            Assert.Equal(newId, project.CreatorUserId);
            Assert.Equal("code", project.Code);
            Assert.Equal("projectName", project.Name);
        }
    }
}
