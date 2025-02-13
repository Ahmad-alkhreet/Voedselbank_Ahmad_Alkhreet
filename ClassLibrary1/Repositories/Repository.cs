using Voedselbank.Database;
using Voedselbank.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Voedselbank.DataAccess.Repositories;


public class Repository<T> : IRepository<T> where T : class
{
    private readonly FoodBankContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(FoodBankContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _context.SaveChanges();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }
}
