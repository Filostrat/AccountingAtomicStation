using CCL.Security.Identity;
using CCL.Security;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Service.Interfaces;
using BLL.DTO;
using AutoMapper;
using DAL.Entities;

namespace BLL.Service.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<ProjectDTO> GetProjects(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();

            if (userType != typeof(Admin))
            {
                throw new MethodAccessException();
            }
            var departmentId = user.DepartmentId;

            var projectEntities = _database.Projects.Find(p => p.DepartmentID == departmentId, pageNumber, pageSize);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();

            var projectDto = mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(projectEntities);
            return projectDto;
        }
    }
}
