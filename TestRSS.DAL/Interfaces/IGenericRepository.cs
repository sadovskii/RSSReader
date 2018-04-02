using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestRSS.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(int id);
        IEnumerable<TEntity> FindList(Func<TEntity, Boolean> predicate);
        TEntity FindOneElement(Func<TEntity, Boolean> predicate);
        void Create(TEntity item);
        void Update(TEntity item);
        void Update(TEntity item, Expression<Func<TEntity, bool>> propertyName);
        void Delete(int id);
    }
}
