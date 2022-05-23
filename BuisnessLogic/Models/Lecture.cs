using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }
        public Cource Course { get; set; }
    }
}
