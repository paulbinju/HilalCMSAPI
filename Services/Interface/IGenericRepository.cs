﻿using System;
using System.Collections.Generic;
using System.Linq;
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



            
    }
}
