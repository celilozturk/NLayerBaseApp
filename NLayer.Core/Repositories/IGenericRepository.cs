using System.Linq.Expressions;

namespace NLayer.Core.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);  //productRepository.GetAll(x=>x.id>5).OrderBy().ToListAsync();
        Task<T> GetByIdAsync(int id);      
        IQueryable<T> Where(Expression<Func<T,bool>> expression);    //productRepository.Where(x=>x.id>5).OrderBy().ToListAsync();
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression);       
        Task AddRangeAsync(IEnumerable<T> entities); //List yerine IEnumerable ile istedigimiz tipe donusturebiliriz.
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
