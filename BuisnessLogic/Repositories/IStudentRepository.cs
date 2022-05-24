﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic.Models;

namespace BuisnessLogic.Repositories
{
    public interface IStudentRepository : CrudRepository<Student>
    {
        public Student getByName(string name);
    }
}
