using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }

        public string Name { get; set; }

        public List<Project> ListProjects { get; set; }

        public List<User> ListUsers { get; set; }
    }
}
