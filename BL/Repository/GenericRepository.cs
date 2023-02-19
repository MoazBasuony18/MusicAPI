using Microsoft.EntityFrameworkCore;
using MusicAPI.BL.IRepository;
using MusicAPI.Models;
using System.Linq.Expressions;

namespace MusicAPI.BL.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MusicDbContext context;
        private readonly DbSet<TEntity> db;
        public GenericRepository(MusicDbContext context)
        {
            this.context = context;
            db=context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            await db.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await db.FindAsync(id);
            db.Remove(entity);
        }

        public void DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            db.RemoveRange(entities);
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orederBy = null, List<string> includes = null)
        {
            IQueryable<TEntity> query = db;
            if(expression != null)
            {
                query = query.Where(expression);
            }
            if(includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            if (orederBy != null)
            {
                query=orederBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<TEntity> query = db;
            if (includes != null)
            {
                foreach (var includePropery in includes)
                {
                    query = query.Include(includePropery);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public void UpdateAsync(TEntity entity)
        {
            db.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
