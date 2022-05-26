

using BuisnessLogic.Models;
using BuisnessLogic.Observer;

namespace WebErebor.Observer
{
    public class AttendanceSubscriber : IAttendanceSubscriber
    {
        private readonly ILogger _logger;

        public AttendanceSubscriber(ILogger logger)
        {
            _logger = logger;
        }

        public void NotifyByEmail(Student student, Lector lector, Course course)
        {
            _logger.LogInformation("Email: {ST}", student.Email);
            _logger.LogInformation("Вы пропустили пропустили более 3 лекций на курсе {C}", course.Title);
            _logger.LogInformation("");

            _logger.LogInformation("Email: {L}", lector.Email);
            _logger.LogInformation("Студент {STS} {STN} пропустил пропустили более 3 лекций на курсе {C}", student.Surname, student.Name, course.Title);
            _logger.LogInformation("");
        }

        public void NotifyBySms(Student student, Course course)
        {
            _logger.LogInformation("Email: {ST}", student.Email);
            _logger.LogInformation("Ваш стрений балл по курсу {C} ниже 4х баллов", course.Title);
            _logger.LogInformation("");
        }
    }
}
