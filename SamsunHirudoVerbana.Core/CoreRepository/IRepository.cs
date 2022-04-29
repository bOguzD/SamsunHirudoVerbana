using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.CoreRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
