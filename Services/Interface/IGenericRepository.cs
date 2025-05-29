using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetbyID(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteRangeAsync(int fid, string fkcolumn);
        Task<IEnumerable<T>> GetAllByForeignKeyAsync(Int32 fid, string fkcolumn);
    }
}
