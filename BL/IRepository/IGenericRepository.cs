using System.Linq.Expressions;

namespace MusicAPI.BL.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync(
            Expression<Func<TEntity,bool>>expression=null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>orederBy=null,
            List<string>includes=null);
        Task<TEntity>GetAsync(Expression<Func<TEntity,bool>>expression=null,List<string>includes=null);
        Task AddAsync(TEntity entity);
        Task DeleteAsync(int id);
        void UpdateAsync(TEntity entity);
        void DeleteRangeAsync(IEnumerable<TEntity> entities);
    }
}
