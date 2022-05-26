using Erebor.Models;

namespace Erebor.Repositories
{
    public interface ILectureRepository : CrudRepository<Lecture>
    {
        public Lecture getByTitle(string title);
    }
}
