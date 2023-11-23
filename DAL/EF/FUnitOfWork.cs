using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class EFUnitOfWork: IUnitOfWork 
    { 
        private readonly DepartmentDbContext _context;
        private DepartmentRepository _departmentRepository;
        private ProjectRepository _employeeRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            _context = new DepartmentDbContext(options);
        }

        public IDepartmentRepository Departments
        {
            get
            {
                _departmentRepository ??= new DepartmentRepository(_context);
                return _departmentRepository;
            }
        }

        public IProjectRepository Projects
        {
            get
            {
                _employeeRepository ??= new ProjectRepository(_context);
                return _employeeRepository;
            }
        }
    
        public void Save()
        {
            _context.SaveChanges();
        }
    
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
                _context.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
