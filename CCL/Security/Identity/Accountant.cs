using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public class Accountant : User
    {
        public Accountant(string firstName, string lastName, string departmentId) : base(firstName, lastName, departmentId, nameof(Accountant))
        {
        }
    }
}
