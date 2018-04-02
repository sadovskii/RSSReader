using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestRSS.DAL.Interfaces;

namespace TestRSS.DAL.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private DbContext db;
        private DbSet<TEntity> dbSet;
        public EFGenericRepository(DbContext db)
        {
            this.db = db;
            dbSet = db.Set<TEntity>();

        }
        public void Create(TEntity item)
        {
            dbSet.Add(item);
        }

        public void Delete(int id)
        {
            TEntity _dbSet = dbSet.Find(id);
            if (_dbSet != null)
                dbSet.Remove(_dbSet);
        }

        public IEnumerable<TEntity> FindList(Func<TEntity, bool> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public TEntity FindOneElement(Func<TEntity, bool> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public void Update(TEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Update(TEntity item, Expression<Func<TEntity, bool>> propertyChange)
        {
            dbSet.Attach(item);
            db.Entry(item).Property(propertyChange).IsModified = true;
        }
    }
}
