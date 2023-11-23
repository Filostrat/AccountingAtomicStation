using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int DepartmentId { get; }
        protected string UserType { get; }

        public User(int userId, string firstName, string lastName, int departmentId, string userType)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            DepartmentId = departmentId;
            UserType = userType;
        }
    }
}
