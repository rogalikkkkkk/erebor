using System.ComponentModel.DataAnnotations.Schema;

namespace Erebor.Models
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime Date { get; set; }

        [ForeignKey("Courses")]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
