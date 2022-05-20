using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public Student Student { get; set; } = null!;
        public Lecture Lecture { get; set; } = null!;
        public bool Attended { get; set; }
        public int Grade { get; set; }
    }
}
