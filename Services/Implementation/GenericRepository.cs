using Microsoft.EntityFrameworkCore;
using Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {


        private readonly AppDbContext _context;
        private DbSet<T> table;
        string errorMessage = string.Empty;
        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            table = context.Set<T>();
        }

        public T Create(T entity)
        {
            table.Add(entity);
            errorMessage = string.Empty;
            _context.SaveChanges();
            return entity;  

        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T> GetbyID(int id)
        {
            return await table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();

        }
    }
}
