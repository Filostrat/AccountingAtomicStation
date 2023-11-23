using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class DepartmentDbContext : DbContext
    {
        public DbSet<Project> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DepartmentDbContext(DbContextOptions options) : base(options) { }
    }
}
