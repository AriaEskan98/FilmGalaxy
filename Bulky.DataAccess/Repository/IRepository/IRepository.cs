using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalaxy.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //T- Category
        Task<IEnumerable<T>> GetAllAsync(string? includeProps = null);
        Task<T?> GetAsync(Expression<Func<T,bool>> filter, string? includeProps = null);
        void Add(T entity);
        
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
