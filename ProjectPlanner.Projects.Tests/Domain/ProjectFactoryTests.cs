using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPlanner.Projects.Domain;
using ProjectPlanner.Projects.Interfaces.Domain.Exceptions;
using ProjectPlanner.Projects.Tests.Mocks;
using Xunit;

namespace ProjectPlanner.Projects.Tests.Domain
{
    public class ProjectFactoryTests
    {
        private ProjectFactory _projectFactory;

        public ProjectFactoryTests()
        {
            var systemUser = new SystemUser();
            var projectRepository = new ProjectRepository();

            _projectFactory = new ProjectFactory(systemUser, projectRepository);
        }

        [Fact]
        public void CreateProject_CanCreateProject()
        {
            var project = _projectFactory.CreateProject("projectCode", "projectName");

            Assert.NotNull(project);
            Assert.Equal(1, project.CreatorUserId);
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
            systemUser.SetUserId(2);
            var projectRepository = new ProjectRepository();
            _projectFactory = new ProjectFactory(systemUser, projectRepository);

            var project = _projectFactory.CreateProject("code", "projectName");

            Assert.NotNull(project);
            Assert.Equal(2, project.CreatorUserId);
            Assert.Equal("code", project.Code);
            Assert.Equal("projectName", project.Name);
        }
    }
}
