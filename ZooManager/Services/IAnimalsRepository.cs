﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManager.Models;

namespace ZooManager.Services
{
    public interface IAnimalsRepository : IRepository<Animal>
    {
    }
}
