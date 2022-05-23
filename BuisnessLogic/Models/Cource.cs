using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Models;

public class Cource
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public Lector Lector { get; set; } 
}