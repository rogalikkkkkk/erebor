using Erebor.Models;
using Erebor.Repositories;
using Moq;
using Xunit;

namespace Erebor.Services;

public class AttendanceReportServiceTests
{
    private readonly IStudentRepository _studentRepository;
    private readonly ILectureRepository _lectureRepository;
    private readonly IAttendanceRepository _attendanceRepository;
    
    public AttendanceReportServiceTests()
    {
        var stud1 = new Student
        {
            Id = 1, Name = "Ilia", Surname = "Rodionov", Age = 20, Email = "ilia@gmail.com", PhoneNumber = "89133466584"
        };
        var stud2 = new Student
        {
            Id = 2, Name = "Daria", Surname = "Lisina", Age = 20, Email = "lisina@gmail.com",
            PhoneNumber = "89313466584"
        };
        var studentsMock = new Mock<IStudentRepository>();
        studentsMock.Setup(r => r.getByName("Ilia")).Returns(stud1);
        studentsMock.Setup(r => r.getByName("Daria")).Returns(stud2);
        _studentRepository = studentsMock.Object;

        var lector = new Lector
            {Id = 1, Name = "Anatoliy", Email = "sergeev@gmai.com", Salary = 1000, Surname = "Sergeev"};
        var course = new Course {Id = 1, Title = "Web Programming", LectorId = 1, Lector = lector};
        var lecture1 = new Lecture
            {Id = 1, Title = "Introduction", Date = new DateTime(2022, 2, 2, 10, 0, 0), CourseId = 1, Course = course};
        var lecture2 = new Lecture
            {Id = 2, Title = "Asp .Net 1", Date = new DateTime(2022, 2, 9, 10, 0, 0), CourseId = 1, Course = course};
        var lecture3 = new Lecture
            {Id = 3, Title = "Asp .Net 2", Date = new DateTime(2022, 2, 9, 10, 0, 0), CourseId = 1, Course = course};
        var lecture4 = new Lecture
            {Id = 4, Title = "Asp .Net 3", Date = new DateTime(2022, 2, 9, 10, 0, 0), CourseId = 1, Course = course};

        var lecturesMock = new Mock<ILectureRepository>();
        lecturesMock.Setup(r => r.getByTitle("Introduction")).Returns(lecture1);
        lecturesMock.Setup(r => r.getByTitle("Asp .Net 1")).Returns(lecture2);
        lecturesMock.Setup(r => r.getByTitle("Asp .Net 2")).Returns(lecture3);
        lecturesMock.Setup(r => r.getByTitle("Asp .Net 3")).Returns(lecture4);
        _lectureRepository = lecturesMock.Object;

        var attendance1 = new Attendance
            {Id = 1, Attended = true, Grade = 3, Lecture = lecture1, Student = stud1, LectureId = 1, StudentId = 1};
        var attendance2 = new Attendance
            {Id = 2, Attended = false, Grade = 4, Lecture = lecture2, Student = stud1, LectureId = 2, StudentId = 1};
        var attendance3 = new Attendance
            {Id = 3, Attended = false, Grade = 5, Lecture = lecture2, Student = stud2, LectureId = 2, StudentId = 2};

        var attendanceMock = new Mock<IAttendanceRepository>();
        attendanceMock.Setup(r => r.getAllByStudent(1)).Returns(new List<Attendance> {attendance1, attendance2});
        attendanceMock.Setup(r => r.getAllByLecture(2)).Returns(new List<Attendance> {attendance3, attendance2});
        _attendanceRepository = attendanceMock.Object;
    }

    [Fact]
    public void GetReportsByStudentsName()
    {
        var service = new AttendanceReportService(_attendanceRepository, _lectureRepository, _studentRepository);
        var result = service.generateReportByStudent("Ilia");

        Assert.Equal(2, result.Data.Count);
        Assert.Single(result.Data.Where(r => r.Entity.Id == 1));
        Assert.Single(result.Data.Where(r => r.Entity.Id == 2));
    }

    [Fact]
    public void GetReportsByLectureTitle()
    {
        var service = new AttendanceReportService(_attendanceRepository, _lectureRepository, _studentRepository);
        var result = service.generateReportByLecture("Asp .Net 1");

        Assert.Equal(2, result.Data.Count);
        Assert.Single(result.Data.Where(r => r.Entity.Id == 1));
        Assert.Single(result.Data.Where(r => r.Entity.Id == 2));
    }
}