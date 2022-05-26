using System.ComponentModel.DataAnnotations.Schema;

namespace BuisnessLogic.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public Student? Student { get; set; } = null!;

        [ForeignKey("Lectures")]
        public int LectureId { get; set; }
        public Lecture? Lecture { get; set; } = null!;

        public bool Attended { get; set; }
        public int Grade { get; set; }
    }
}
