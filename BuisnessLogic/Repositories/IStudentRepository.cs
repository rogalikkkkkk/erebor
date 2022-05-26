using Erebor.Models;

namespace Erebor.Repositories
{
    public interface IStudentRepository : CrudRepository<Student>
    {
        public Student getByName(string name);
    }
}
