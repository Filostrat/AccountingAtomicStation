using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string DepartmentId { get; }
        protected string UserType { get; }

        public User(string firstName, string lastName, string departmentId, string userType)
        {
            FirstName = firstName;
            LastName = lastName;
            DepartmentId = departmentId;
            UserType = userType;
        }
    }
}
