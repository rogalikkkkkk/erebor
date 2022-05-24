using BuisnessLogic.Models;
using BuisnessLogic.Repositories;
using Erebor.Application;

namespace Erebor.Repositories;

public class LectorRepository : ILectorRepository
{
    private readonly ApplicationDBContext _db = new();

    public List<Lector> GetAll()
    {
        return _db.Lectors.ToList();
    }

    public Lector GetById(int id)
    {
        var lector = _db.Lectors.FirstOrDefault(l => l.Id == id);
        if (lector == null)
        {
            throw new Exception("По данному ID не было найдено записей в таблице лекторов");
        }

        return _db.Lectors.First(l => l.Id == id);
    }

    public Lector Save(Lector entity)
    {
        _db.Update(entity);
        _db.SaveChanges();
        return _db.Lectors.First(l => l.Id == entity.Id);
    }

    public void Delete(Lector entity)
    {
        if (!_db.Lectors.Contains(entity)) return;
        _db.Remove(entity);
        _db.SaveChanges();
    }
}