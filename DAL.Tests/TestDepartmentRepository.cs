using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repositories.Impl;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestDepartmentRepository : BaseRepository<Department>
    {
        public TestDepartmentRepository(DbContext context) : base(context)
        {
        }
    }
}
    