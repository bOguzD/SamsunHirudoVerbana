using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SamsunHirudoVerbana.Core.CoreRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly SamsunHirudoVerbanaContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public Repository(SamsunHirudoVerbanaContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public async Task Insert(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        [Obsolete("Async ve unitofwork olduğu için return e bakmak lazım")]
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        [Obsolete("Async ve unitofwork olduğu için return e bakmak lazım")]
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
