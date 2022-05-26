using System.ComponentModel.DataAnnotations.Schema;


namespace BuisnessLogic.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }

        [ForeignKey("Cources")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
