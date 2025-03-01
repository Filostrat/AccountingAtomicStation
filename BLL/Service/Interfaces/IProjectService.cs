﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDTO> GetProjects(int page);
    }
}
