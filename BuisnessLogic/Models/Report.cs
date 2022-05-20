using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models
{
    internal class Report<T>
    {
        public List<ReportEntity<T>> Data { get; set; }
    }
}
