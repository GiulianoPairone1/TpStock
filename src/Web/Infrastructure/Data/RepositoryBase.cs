using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public abstract class RepositoryBase<T> :IRepositoryBase<T> where T : class
    {
        private readonly DbContext _context;
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        
        public virtual  List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T FindByCondition(Func<T, bool> condition)
        {
            return _context.Set<T>().FirstOrDefault(condition);
        }


        public T add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }

     
    }
}
