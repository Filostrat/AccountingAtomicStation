﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Project
    {
        public int ProjectID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DepartmentID { get; set; }
    }
}
