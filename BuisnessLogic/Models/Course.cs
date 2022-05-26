using System.ComponentModel.DataAnnotations.Schema;

namespace BuisnessLogic.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;

    [ForeignKey("Lectors")]
    public int LectorId { get; set; }
    public Lector? Lector { get; set; } 
}