using BLL.Service.Impl;
using BLL.Service.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Tests
{
    public class ProjectServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new ProjectService(nullUnitOfWork));
        }

        [Fact]
        public void GetProject_UserIsAccountant_ThrowMethodAccessException()
        {
            User user = new Accountant(1,"Max","Matvienko",1);
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            IProjectService projectServicey = new ProjectService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => projectServicey.GetProjects(0));
        }

        [Fact]
        public void GetProject_ProjectFromDAL_CorrectMappingToProjectDTO()
        {
            User user = new Admin(1, "Max", "Matvienko", 1);
            SecurityContext.SetUser(user);

            var projectService = GetProjectService();

            var actualProjectDto = projectService.GetProjects(0).First();

            Assert.True(actualProjectDto.ProjectID == 1 && actualProjectDto.Name == "TestName" && actualProjectDto.Description == "TestDescription");

        }

        private IProjectService GetProjectService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedProject = new Project()
            {
                ProjectID = 1,
                Name = "TestName",
                Description = "TestDescription"
            };
            var mockDbSet = new Mock<IProjectRepository>();

            mockDbSet.Setup(p => p.Find(It.IsAny<Func<Project, bool>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Project>() { expectedProject });

            mockContext.Setup(context => context.Projects).Returns(mockDbSet.Object);
            
            IProjectService projectRepository = new ProjectService(mockContext.Object);

            return projectRepository;
        }
    }
}
