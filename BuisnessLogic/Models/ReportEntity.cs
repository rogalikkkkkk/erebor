using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models
{
    internal class ReportEntity<T>
    {
        public T Entity { get; set; }
        public bool Attanded { get; set; }
        public int Grade { get; set; }

    }
}
