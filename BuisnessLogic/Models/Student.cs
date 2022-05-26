namespace Erebor.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
