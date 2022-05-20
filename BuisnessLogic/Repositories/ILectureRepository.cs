using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogic.Models;

namespace BuisnessLogic.Repositories
{
    internal interface ILectureRepository : CrudRepository<Lecture>
    {
        public Lecture getByTitle(string title);
    }
}
