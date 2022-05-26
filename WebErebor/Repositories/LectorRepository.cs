using Erebor.Models;
using Erebor.Application;

namespace Erebor.Repositories
{
    public class LectorRepository : ILectorRepository
    {
        private readonly ApplicationDbContext _db;

        public LectorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Lector> GetAll()
        {
            return _db.Lectors.ToList();
        }

        public Lector GetById(int id)
        {
            var lector = _db.Lectors.FirstOrDefault(l => l.Id == id);
            if (lector == null) throw new Exception("По данному ID не было найдено записей в таблице лекторов");

            return lector;
        }

        public Lector Save(Lector entity)
        {
            var lector = _db.Update(entity);
            _db.SaveChanges();
            return lector.Entity;
        }

        public void Delete(Lector entity)
        {
            if (!_db.Lectors.Contains(entity)) return;
            _db.Remove(entity);
            _db.SaveChanges();
        }
    }
}