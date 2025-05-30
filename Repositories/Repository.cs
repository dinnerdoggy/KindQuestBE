using Microsoft.EntityFrameworkCore;
using KindQuest.Data;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly KindQuestDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(KindQuestDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.ToList();

    public T GetById(int id) => _dbSet.Find(id);

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
}